using FifaLib.Models;
using System.CodeDom;

namespace MainForm {
    public partial class Settings : Form {
        private Gender selectedGender = Gender.Male;
        private Language selectedLanguage = Language.English;
        private readonly string appData = "appSettings.txt";

        public Settings() {
            InitializeComponent();
        }

        private void cbxLanguage_SelectedIndexChanged(object sender, EventArgs e) {
            selectedLanguage = (Language)Enum.Parse(typeof(Language), cbxLanguage.SelectedValue.ToString());
        }

        private void btnConfirm_Click(object sender, EventArgs e) {
            string[] data = new string[] { $"Language:{selectedLanguage}", $"Gender:{selectedGender}" };
            File.WriteAllLines(appData, data);
            Close();
        }

        private void Settings_Load(object sender, EventArgs e) {
            cbxLanguage.Items.Clear();

            cbxLanguage.DataSource = Enum.GetValues(typeof(Language));
            cbxLanguage.SelectedIndex = 0;

            if (File.Exists(appData)) {
                try {
                    string[] lines = File.ReadAllLines(appData);
                    for (int i = 0; i < lines.Length; i++) {
                        lines[i] = lines[i].Trim().Split(':')[1];
                    }
                    selectedLanguage = (Language)Enum.Parse(typeof(Language), lines[0]);
                    selectedGender = (Gender)Enum.Parse(typeof(Gender), lines[1]);
                }
                catch (Exception) {
                    Console.WriteLine($"\"{appData}\" parse failed");
                    return;
                }
                cbxLanguage.SelectedItem = selectedLanguage;

                if (selectedGender == Gender.Male) {
                    rbMale.Checked = true;
                    rbFemale.Checked = !rbMale.Checked;
                }
                else {
                    rbFemale.Checked = true;
                    rbMale.Checked = !rbFemale.Checked;
                }
            }
            else {
                cbxLanguage.SelectedItem = Language.English;
                selectedLanguage = Language.English;
            }
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e) => selectedGender = Gender.Female;

        private void rbMale_CheckedChanged(object sender, EventArgs e) => selectedGender = Gender.Male;

        private void btnCancel_Click(object sender, EventArgs e) => Close();
    }
}
