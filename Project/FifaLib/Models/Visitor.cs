using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaLib.Models {
    public class Visitor {
        [JsonProperty("location")]
        public string Location { get; set; }

        [JsonProperty("attendance")]
        public long Attendance { get; set; }

        [JsonProperty("home_team_country")]
        public string HomeTeamCountry { get; set; }

        [JsonProperty("away_team_country")]
        public string AwayTeamCountry { get; set; }

        public override string ToString() {
            return $"Loaction:{Location},Attendance:{Attendance},HomeTeamCountry:{HomeTeamCountry},AwayTeamCountry:{AwayTeamCountry}";
        }

        public string ToDisplay() {
            return $"Location: {Location} Attendance: {Attendance}, Home team: {HomeTeamCountry} | Away tema:{AwayTeamCountry}";
        }
    }
}
