using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FifaLib.Models {
    public class GameEvent {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("type_of_event")]
        public string? TypeOfEvent { get; set; }

        [JsonProperty("player")]
        public  string? PlayerName { get; set; }

        [JsonProperty("time")]
        public string? Time { get; set; }

        public Player pp { get; set; }

        public override string ToString() {
            return $"Id:{Id} TypeOfEvent:{TypeOfEvent} Player:{PlayerName} Time:{Time}";
        }

        public string Parse() {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Player: {PlayerName} ").Append($" Goals: {1}").Append($" Yellow card: {1}");

            return sb.ToString();
        }
    }
}
