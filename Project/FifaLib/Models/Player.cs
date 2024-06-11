using Newtonsoft.Json;

namespace FifaLib.Models {
    public class Player {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("captain")]
        public bool IsCaptain { get; set; }

        [JsonProperty("shirt_number")]
        public long ShirtNumber { get; set; }

        [JsonProperty("position")]
        public string? Position { get; set; }

        [JsonIgnore]
        public bool IsFavourite { get; set; }

        [JsonIgnore]
        public string? PicturePath { get; private set; }

        public override string ToString() {
            return $"Name:{Name} IsCaptain:{(IsCaptain ? "true" : "false")} ShirtNumber:{ShirtNumber} Position:{Position}";
        }

        public string ToDisplay() => $"{Name} ({ShirtNumber})";
    }
}
