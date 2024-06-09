using FifaLib.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace FifaLib {
    public class Repo {
        private readonly string API_MenTeamsResults = "https://worldcup-vua.nullbit.hr/men/teams/results";
        private readonly string API_WomenTeamsResults = "https://worldcup-vua.nullbit.hr/women/teams/results";
        private readonly string API_MenMatches = "https://worldcup-vua.nullbit.hr/men/matches";
        private readonly string API_WomenMatches = "https://worldcup-vua.nullbit.hr/women/matches";
        private readonly string API_Filter = "/country?fifa_code=";

        private string dataFolder = string.Empty;

        private readonly string FILE_Men;
        private readonly string FILE_Women;

        private readonly HttpClient _clinet;

        private JArray _matches;

        public Repo() {
            _clinet = new HttpClient();
            _matches = new JArray();;

            try {
                FILE_Men = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + @"\FifaLib\Data\men";
                FILE_Women = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + @"\FifaLib\Data\women";
            }
            catch (Exception e) {
                throw new IOException("Data folders are corupted or missing\n" + e.Message);
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

        public async Task<List<Player>> FetchPlayers(Gender gender, DataSource source, string filter) {
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

            _matches.Clear();
            _matches = JArray.Parse(jstring);

            try {
                JArray jPlayers = new JArray();
                if (_matches[0]["home_team"].Value<string>("code") == filter) {
                    jPlayers = new JArray(_matches[0]["home_team_statistics"]["starting_eleven"].Union((JArray)_matches[0]["home_team_statistics"]["substitutes"]));
                }
                else {
                    jPlayers = new JArray(_matches[0]["away_team_statistics"]["starting_eleven"].Union((JArray)_matches[0]["away_team_statistics"]["substitutes"]));
                }
                return jPlayers.ToObject<List<Player>>();
            }
            catch (Exception e) {
                Console.WriteLine($"Player read failed from source: \"{source}\"\n" + e.ToString());
                throw new IOException();
            }
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
            } catch (Exception e){
                Console.WriteLine("File read failed, file is corupted or missing\n" + e.Message);
                return string.Empty;
            }
        }

        public void SaveToJsonFile<T>(T data, string path) {
            var jsonString = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
            //File.WriteAllText(path, jsonString);
        }
    }
}
