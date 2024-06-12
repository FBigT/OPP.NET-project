using FifaLib.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;

namespace FifaLib {
    public class Repo {
        private static readonly string API_MenTeamsResults = "https://worldcup-vua.nullbit.hr/men/teams/results";
        private static readonly string API_WomenTeamsResults = "https://worldcup-vua.nullbit.hr/women/teams/results";
        private static readonly string API_MenMatches = "https://worldcup-vua.nullbit.hr/men/matches";
        private static readonly string API_WomenMatches = "https://worldcup-vua.nullbit.hr/women/matches";
        private static readonly string API_Filter = "/country?fifa_code=";

        private static readonly string FILE_Men;
        private static readonly string FILE_Women;

        private static readonly HttpClient _clinet;

        private static JArray _matches;

        private static readonly string playerImagePath;
        private static readonly string appSettingsPath;

        private static readonly string appSettingsFile = "appSettings.txt";
        private static readonly string userSetingsFile = "userSettings.txt";

        private static readonly Repo instance = new Repo();

        public static Repo Instance { get { return instance; } }

        private string? dataFilter;
        private string? jData;

        //public delegate void MatcheChangeEventHandler(object sender, EventArgs args); 
        //public event MatcheChangeEventHandler OnMatcheChange;

        static Repo() {
            _clinet = new HttpClient();
            _matches = new JArray(); ;

            try {
                playerImagePath = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + @"\Assets\PlayerImages";
                appSettingsPath = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + @"\AppSettings";

                FILE_Men = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + @"\FifaLib\Data\men";
                FILE_Women = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + @"\FifaLib\Data\women";

                CheckDirectory();
            }
            catch (Exception e) {
                throw new IOException("Data folders are corupted or missing\n" + e.Message);
            }
        }

        public void SetDataFilter(string? filter) => dataFilter = filter;

        public async Task<List<GameEvent>> FetchEvents(Gender gender, DataSource source, string filter) {
            if (dataFilter != filter || jData == null) {
                jData = await FetchMatchesFiltered(gender, source, filter);
                dataFilter = filter;
            }

            _matches.Clear();
            _matches = JArray.Parse(jData);

            try {

                JArray jEvents = new JArray();
                List<GameEvent> gameEvents = new List<GameEvent>();

                foreach (JObject game in _matches) {
                    if (game["home_team"].Value<string>("code") == filter)
                        jEvents = (JArray)game["home_team_events"];
                    else
                        jEvents = (JArray)game["away_team_events"];
                    gameEvents.AddRange(jEvents.ToObject<List<GameEvent>>());
                }
                return gameEvents;
            }
            catch (Exception e) {
                Console.WriteLine($"Player event read failed from source: \"{source}\"\n" + e.ToString());
                throw new IOException();
            }
        }

        public async Task<List<Player>> FetchPlayers(Gender gender, DataSource source, string filter) {
            if (dataFilter != filter || jData == null) {
                jData = await FetchMatchesFiltered(gender, source, filter);
                dataFilter = filter;
            }

            _matches.Clear();
            _matches = JArray.Parse(jData);

            try {
                JArray jPlayers = new JArray();
                if (_matches[0]["home_team"].Value<string>("code") == filter)
                    jPlayers = new JArray(_matches[0]["home_team_statistics"]["starting_eleven"].Union((JArray)_matches[0]["home_team_statistics"]["substitutes"]));
                else
                    jPlayers = new JArray(_matches[0]["away_team_statistics"]["starting_eleven"].Union((JArray)_matches[0]["away_team_statistics"]["substitutes"]));

                return jPlayers.ToObject<List<Player>>();
            }
            catch (Exception e) {
                Console.WriteLine($"Player read failed from source: \"{source}\"\n" + e.ToString());
                throw new IOException();
            }
        }

        public async Task<List<TeamResults>> FetchTeams(Gender gender, DataSource source) {
            string jstring = string.Empty;

            if (source == DataSource.API) {
                string path = gender == Gender.Male ? API_MenTeamsResults : API_WomenTeamsResults;
                jstring = await ExtractDataSerialized(source, path);
            }
            else if (source == DataSource.File) {
                StringBuilder sb = new StringBuilder();
                string path = gender == Gender.Male ? FILE_Men : FILE_Women;
                sb.Append(path).Append(@$"\teams.json");
                jstring = await ExtractDataSerialized(source, sb.ToString());
            }
            return JsonConvert.DeserializeObject<List<TeamResults>>(jstring);
        }

        public async Task<List<Visitor>> FetchVisitors(Gender gender, DataSource source, string filter) {
            if (dataFilter != filter || jData == null) {
                jData = await FetchMatchesFiltered(gender, source, filter);
                dataFilter = filter;
            }

            _matches.Clear();
            _matches = JArray.Parse(jData);

            try {

                JArray jVisitors = new JArray();
                List<Visitor> visitors = new List<Visitor>();

                foreach (JObject game in _matches) {
                    visitors.Add(game.ToObject<Visitor>());
                }
                return visitors;
            }
            catch (Exception e) {
                Console.WriteLine($"Visitor read failed from source: \"{source}\"\n" + e.ToString());
                throw new IOException();
            }
        }

        private async Task<string> FetchMatchesFiltered(Gender gender, DataSource source, string filter) {
            StringBuilder sb = new StringBuilder();
            string jstring = string.Empty;
            if (source == DataSource.API) {
                sb.Clear();
                string path = gender == Gender.Male ? API_MenMatches : API_WomenMatches;
                sb.Append(path).Append(API_Filter).Append(filter);
                jstring = await ExtractDataSerialized(source, sb.ToString());
            }
            else if (source == DataSource.File) {
                sb.Clear();
                string path = gender == Gender.Male ? FILE_Men : FILE_Women;
                sb.Append(path).Append(@$"\matches.json");
                jstring = await ExtractDataSerialized(source, sb.ToString());
            }
            return jstring;
        }

        private async Task<string> ExtractDataSerialized(DataSource source, string path) {
            if (source == DataSource.API) return await FetchFromApiAsync(path);
            if (source == DataSource.File) return FetchFromJsonFile(path);
            throw new Exception("Data source is not set or is invalid");
        }

        private async Task<string> FetchFromApiAsync(string url) {
            var response = await _clinet.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        private string FetchFromJsonFile(string path) {
            try {
                return File.ReadAllText(path);
            }
            catch (Exception e) {
                Console.WriteLine("File read failed, file is corupted or missing\n" + e.Message);
                return string.Empty;
            }
        }

        private static void CheckDirectory() {
            if (!Directory.Exists(playerImagePath)) {
                Directory.CreateDirectory(playerImagePath);
            }
            if (!Directory.Exists(appSettingsPath)) {
                Directory.CreateDirectory(appSettingsPath);
            }
        }

        public AppSettingsData GetAppSettings() {

            try {
                string[] lines = File.ReadAllLines(Path.Combine(appSettingsPath, appSettingsFile));
                for (int i = 0; i < lines.Length; i++) {
                    lines[i] = lines[i].Trim().Split(':')[1];
                }

                AppSettingsData asd = new AppSettingsData();
                asd.language = (Language)Enum.Parse(typeof(Language), lines[0]);
                asd.gender = (Gender)Enum.Parse(typeof(Gender), lines[1]);
                asd.source = (DataSource)Enum.Parse(typeof(DataSource), lines[2]);

                return asd;
            }
            catch (Exception) {
                Console.WriteLine("Settings are invalid or corupted");
                throw new IOException();
            }
        }

        public bool SaveAppSettings(Language language, Gender gender, DataSource dataSource) {
            try {
                string[] data = new string[] { $"Language:{language}", $"Gender:{gender}", $"Datasource:{dataSource}" };
                File.WriteAllLines(Path.Combine(appSettingsPath, appSettingsFile), data);
                return true;
            }
            catch (Exception e) {
                Console.WriteLine("Data save failed\n" + e.Message);
                return false;
            }
        }

        public bool SaveUserSettings(string championship, bool overwrite, params string[] favs) {
            try {
                string[] data;

                if (!overwrite) {
                    data = new string[1 + favs.Count()];
                    favs.CopyTo(data, 1);
                }
                else {
                    UserSettingsData usd = GetUserSettings();
                    string[]? loadeldData = usd.faves;
                    data = new string[1 + loadeldData.Count()];
                    loadeldData.CopyTo(data, 1);
                }

                data[0] = championship;

                File.WriteAllText(Path.Combine(appSettingsPath, userSetingsFile), "");

                File.WriteAllLines(Path.Combine(appSettingsPath, userSetingsFile), data);
                return true;
            }
            catch (Exception e) {
                Console.WriteLine("Data save failed\n" + e.Message);
                return false;
            }
        }

        public UserSettingsData GetUserSettings() {

            try {
                string[] lines = File.ReadAllLines(Path.Combine(appSettingsPath, userSetingsFile));

                UserSettingsData usd = new UserSettingsData();
                usd.champoinship = lines[0];
                var data = lines.Skip(1);
                usd.faves = data.ToArray();

                return usd;
            }
            catch (Exception) {
                Console.WriteLine("Settings are invalid or corupted");
                throw new IOException();
            }
        }

        public void DestroyUserSettings() => File.Delete(Path.Combine(appSettingsPath, userSetingsFile));

        public void DestroySettings() => File.Delete(Path.Combine(appSettingsPath, appSettingsFile));

        public string SaveImage(string path, Player player) {
            string extension = Path.GetExtension(path);
            string copyPath = Path.Combine(playerImagePath, player.Name + extension);
            try {
                File.Copy(path, copyPath, true);
                return copyPath;
            }
            catch (Exception) {
                throw new IOException();
            }
        }

        public (string?, bool) GetImagePath(Player player) {
            try {
                var files = System.IO.Directory.GetFiles(playerImagePath, player.Name + ".*");
                if (files.Length > 0) return (files[0], true);
                return (null, false);
            }
            catch (Exception) {
                return (null, false);
            }
        }

        public bool AppSettingExists() {
            return File.Exists(Path.Combine(appSettingsPath, appSettingsFile));
        }

        public bool UserSettingExists() {
            return File.Exists(Path.Combine(appSettingsPath, userSetingsFile));
        }
    }
}
