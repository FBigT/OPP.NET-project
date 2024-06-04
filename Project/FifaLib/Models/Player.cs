using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaLib.Models {
    public class Player {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("captain")]
        public bool IsCaptain { get; set; }

        [JsonProperty("shirt_number")]
        public long ShirtNumber { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        public override string ToString() {
            return $"Name:{Name} IsCaptain:{(IsCaptain ? "true" : "false")} ShirtNumber:{ShirtNumber} Position:{Position}";
        }
    }
}
