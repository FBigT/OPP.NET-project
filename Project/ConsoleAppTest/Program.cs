using FifaLib;
using FifaLib.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;


namespace ConsoleAppTest {
    internal class Program {
        static async Task Main(string[] args) {

            Repo repo = new Repo();
            try {
                var menMatch = await repo.ExtractData<List<TeamResults>>(Gender.Male, DataSource.API);
                var womenMatch = await repo.ExtractData<List<TeamResults>>(Gender.Female, DataSource.API);

                //menMatch.ForEach(m => Console.WriteLine($"{m.Country} ({m.FifaCode}) - Wins: {m.Wins}, Losses: {m.Losses}"));


                //repo.SaveToJsonFile<List<TeamResults>>(menMatch, @"Data\MenTeamsResults.txt");
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
        }
    }
}
