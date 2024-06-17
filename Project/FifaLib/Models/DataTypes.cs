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
        public Resolution resolution;

        public AppSettingsData(DataSource source, Language language, Gender gender, Resolution resolution) {
            this.source = source;
            this.language = language;
            this.gender = gender;
            this.resolution = resolution;
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

    public enum Resolution {
        R_1680_1050,
        R_1920_1080,
        R_2560_1440,
        FullScreen
    }

    public static class ResolutionReder {
        public static string ResolutionToString(Resolution r) {
            string? data = Enum.GetName(typeof(Resolution), r);
            if (data == null) return string.Empty;

            var segments = data.Split('_');

            if (segments[0] == "R") {
                return $"{segments[1]} x {segments[2]}";
            }
            else return data;
        }

        public static int[] ResolutionToIntArray(Resolution r) {
            var d = ResolutionToString(r);
            d = d.Trim();
            try {
                if (d == ResolutionToString(Resolution.FullScreen)) {
                    return new int[] { 0, 0 };
                }
                return new int[] { int.Parse(d.Split('x')[0]), int.Parse(d.Split('x')[1]) };
            }
            catch (Exception) {
                throw new FormatException();
            }
        }
    }
}
