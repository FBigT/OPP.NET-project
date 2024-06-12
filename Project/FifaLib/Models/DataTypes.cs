using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifaLib.Models {
    public enum DataSource {
        File,
        API
    }

    public enum Gender {
        Male,
        Female
    }

    public enum Language {
        English,
        Croatian
    }

    public struct AppSettingsData {
        public DataSource source;
        public Language language;
        public Gender gender;

        public AppSettingsData(DataSource source, Language language, Gender gender) {
            this.source = source;
            this.language = language;
            this.gender = gender;
        }
    }

    public struct UserSettingsData {
        public string? champoinship;
        public string[]? faves;

        public UserSettingsData(string? champoinship, string[]? faves) {
            this.champoinship = champoinship;
            this.faves = faves;
        }
    }
}
