using FifaLib;
using FifaLib.Models;
using System.CodeDom;

namespace MainForm {
    public partial class Settings : Form {
        private Gender selectedGender = Gender.Male;
        private Language selectedLanguage = Language.English;
        private DataSource selectedDatasource = DataSource.API;

        public Settings() {
            InitializeComponent();
        }

        private void cbxLanguage_SelectedIndexChanged(object sender, EventArgs e) {
            selectedLanguage = (Language)Enum.Parse(typeof(Language), cbxLanguage.SelectedValue.ToString());
        }

        private void btnConfirm_Click(object sender, EventArgs e) {
            Repo.Instance.SaveAppSettings(selectedLanguage, selectedGender, selectedDatasource);
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void Settings_Load(object sender, EventArgs e) {
            cbxLanguage.Items.Clear();

            cbxLanguage.DataSource = Enum.GetValues(typeof(Language));
            cbxLanguage.SelectedIndex = 0;

            if (Repo.Instance.AppSettingExists()) {
                try {
                    AppSettingsData ads = Repo.Instance.GetAppSettings();
                    selectedLanguage = ads.language;
                    selectedGender = ads.gender;
                    selectedDatasource = ads.source;

                    if (selectedGender == Gender.Male) {
                        rbMale.Checked = true;
                        rbFemale.Checked = !rbMale.Checked;
                    }
                    else {
                        rbFemale.Checked = true;
                        rbMale.Checked = !rbFemale.Checked;
                    }

                    if (selectedDatasource == DataSource.API) {
                        rbAPI.Checked = true;
                        rbFile.Checked = !rbAPI.Checked;
                    }
                    else {
                        rbFile.Checked = true;
                        rbAPI.Checked = !rbFile.Checked;
                    }

                    SetLocalization();
                }
                catch (Exception) {
                    MessageBox.Show("An error accured while reading appSettings.txt", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else {

            }
        }
        private void SetLocalization() {
            if (selectedLanguage == Language.Croatian) {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("hr");
            }
            else {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-GB");
            }
            Controls.Clear();
            InitializeComponent();

            cbxLanguage.DataSource = Enum.GetValues(typeof(Language));

            if (selectedLanguage == Language.Croatian) {
                cbxLanguage.SelectedIndex = 1;
            }
            else {
                cbxLanguage.SelectedIndex = 0;
            }

            if (selectedGender == Gender.Male) {
                rbMale.Checked = true;
                rbFemale.Checked = !rbMale.Checked;
            }
            else {
                rbFemale.Checked = true;
                rbMale.Checked = !rbFemale.Checked;
            }

            if (selectedDatasource == DataSource.API) {
                rbAPI.Checked = true;
                rbFile.Checked = !rbAPI.Checked;
            }
            else {
                rbFile.Checked = true;
                rbAPI.Checked = !rbFile.Checked;
            }
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e) => selectedGender = Gender.Female;

        private void rbMale_CheckedChanged(object sender, EventArgs e) => selectedGender = Gender.Male;

        private void btnCancel_Click(object sender, EventArgs e) => Close();

        private void rbAPI_CheckedChanged(object sender, EventArgs e) => selectedDatasource = DataSource.API;

        private void rbFile_CheckedChanged(object sender, EventArgs e) => selectedDatasource = DataSource.File;
    }
}
