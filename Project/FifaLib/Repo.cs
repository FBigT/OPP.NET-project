using FifaLib.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace FifaLib {
    public class Repo {
        private readonly string API_MenTeamsResults = "https://worldcup-vua.nullbit.hr/men/teams/results";
        private readonly string API_WomenTeamsResults = "https://worldcup-vua.nullbit.hr/women/teams/results";
        private readonly string API_MenMatches = "https://worldcup-vua.nullbit.hr/men/matches";
        private readonly string API_WomenMatches = "https://worldcup-vua.nullbit.hr/women/matches";
        private readonly string API_Filter = "/country?fifa_code=";

        private readonly HttpClient _clinet;

        private JArray _matches;

        public Repo() {
            _clinet = new HttpClient();
            _matches = new JArray();
        }

        public async Task<List<TeamResults>> FetchTeams(Gender gender, DataSource source) {
            string path = gender == Gender.Male ? API_MenTeamsResults : API_WomenTeamsResults;
            var jstring = await ExtractDataSerialized(source, path);
            return JsonConvert.DeserializeObject<List<TeamResults>>(jstring);
        }

        public async Task<List<Player>> FetchPlayers(Gender gender, DataSource source, string filter) {
            string path = gender == Gender.Male ? API_MenMatches : API_WomenMatches;
            StringBuilder sb = new StringBuilder();
            sb.Append(path).Append(API_Filter).Append(filter);
            var jstring = await ExtractDataSerialized(source, sb.ToString());
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
            if (source == DataSource.File) return FetchFromJsonFile("");
            throw new Exception("Data source is not set or is invalid");
        }

        private async Task<string> FetchFromApiAsync(string url) {
            var response = await _clinet.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        private string FetchFromJsonFile(string path) {
            return File.ReadAllText(path);
        }

        public void SaveToJsonFile<T>(T data, string path) {
            var jsonString = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
            //File.WriteAllText(path, jsonString);
        }
    }
}
