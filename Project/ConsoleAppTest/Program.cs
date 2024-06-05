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


                List<TeamResults> tt = await repo.FetchTeams(Gender.Male, DataSource.API);
                List<Player> pp = await repo.FetchPlayers(Gender.Male, DataSource.API, "ENG");

                pp.ForEach(Console.WriteLine);

                //menMatch.ForEach(m => Console.WriteLine($"{m.Country} ({m.FifaCode}) - Wins: {m.Wins}, Losses: {m.Losses}"));

                Console.WriteLine("\n\n");


                //repo.SaveToJsonFile<List<TeamResults>>(menMatch, @"Data\MenTeamsResults.txt");

                //var stuff = await repo.GetMatches(Gender.Male, DataSource.API);
                //stuff.ForEach(Console.WriteLine);
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
        }
    }
}
