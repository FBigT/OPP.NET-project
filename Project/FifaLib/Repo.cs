using FifaLib.Models;
using Newtonsoft.Json;

namespace FifaLib {
    public class Repo {
        private readonly string API_MenTeamsResults = "https://worldcup-vua.nullbit.hr/men/teams/results";
        private readonly string API_WomenTeamsResults = "https://worldcup-vua.nullbit.hr/women/teams/results";
        private readonly string API_MenMatches = "https://worldcup-vua.nullbit.hr/men/matches";
        private readonly string API_WomenMatches = "https://worldcup-vua.nullbit.hr/women/matches";

        private readonly HttpClient _clinet;

        public Repo() {
            _clinet = new HttpClient();
        }

        public async Task<T> ExtractData<T>(Gender gender, DataSource source) {
            if (source == DataSource.API) {
                string url = gender == Gender.Male ? API_MenTeamsResults : API_WomenTeamsResults;
                return await FetchFromApiAsync<T>(url);
            }
            else {
                return FetchFromJsonFile<T>("");
            }
        }

        private async Task<T> FetchFromApiAsync<T>(string url) {
            var response = await _clinet.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        private T FetchFromJsonFile<T>(string path) {
            var jsonString = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public void SaveToJsonFile<T>(T data, string path) {
            var jsonString = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
            //File.WriteAllText(path, jsonString);
        }
    }
}
