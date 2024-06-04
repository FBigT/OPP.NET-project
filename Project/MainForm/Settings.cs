using FifaLib.Models;

namespace MainForm {
    public partial class Settings : Form {
        
        private Gender selectedGender = Gender.Male;
        private string selectedLanguage = "English";
        private readonly string[] languages = new string[] { "English", "Croatian" };

        public Settings() {
            InitializeComponent();
        }

        private void cbxLanguage_SelectedIndexChanged(object sender, EventArgs e) {
            selectedLanguage = languages[cbxLanguage.SelectedIndex];
        }

        private void btnConfirm_Click(object sender, EventArgs e) {
            string[] data = new string[] { $"Language:{selectedLanguage}", $"Gender:{selectedGender}"};
            File.WriteAllLines("appSettings.txt", data);
        }

        private void Settings_Load(object sender, EventArgs e) {
            cbxLanguage.Items.Clear();
            foreach (string language in languages) {
                cbxLanguage.Items.Add(language);
            }
            cbxLanguage.SelectedIndex = 0;
            selectedLanguage = languages[0];
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e) {
            selectedGender = Gender.Female;
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e) {
            selectedGender = Gender.Male;
        }
    }
}
