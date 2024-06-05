using FifaLib;
using FifaLib.Models;

namespace MainForm {
    public partial class Main : Form {

        private Gender currentGender;
        private Language currentLlanguage;
        private readonly string appData = "appSettings.txt";

        public Main() {
            repo = new Repo();
            InitializeComponent();
        }

        private readonly Repo repo;

        private void ValidateForm() {
            if (!File.Exists(appData)) {
                Settings settingsForm = new Settings();
                settingsForm.ShowDialog();
                if (!File.Exists(appData)) Dispose();
            }

            try {
                string[] lines = File.ReadAllLines(appData);
                for (int i = 0; i < lines.Length; i++) {
                    lines[i] = lines[i].Trim().Split(':')[1];
                }
                currentLlanguage = (Language)Enum.Parse(typeof(Language), lines[0]);
                currentGender = (Gender)Enum.Parse(typeof(Gender), lines[1]);
            }
            catch (Exception) {
                MessageBox.Show("Settings are invalid or corupted.\nSettings must be set again.", "Settings error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                File.Delete(appData);
                Dispose();
            }
        }

        private void Main_Load(object sender, EventArgs e) {
            ValidateForm();
            SetRepresentationCbx();
        }

        private async void SetRepresentationCbx() {
            cbxRepresentation.Items.Clear();
            var teams = await repo.FetchTeams(currentGender, DataSource.API);

            teams.ForEach(x => { cbxRepresentation.Items.Add($"{x.Country}({x.FifaCode})"); });
            cbxRepresentation.SelectedIndex = 0;
        }

        private async void SetPlayerSelectionList() {
            var players = await repo.FetchPlayers(currentGender, DataSource.API, GetFilter());
            cblPlayers.Items.Clear();
            players.ForEach(player => { 
                cblPlayers.Items.Add($"{player.Name} ({player.ShirtNumber})"); 
            });
        }

        private string GetFilter() {
            var item = cbxRepresentation.SelectedItem;

            if (item == null) return "ENG";

            return item.ToString().Split('(')[1].Split(')')[0];
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e) {
            Settings settingsForm = new Settings();
            settingsForm.ShowDialog();
            ValidateForm();
            SetRepresentationCbx();
        }

        private void cbxRepresentation_SelectedIndexChanged(object sender, EventArgs e) {
            SetPlayerSelectionList();
        }
    }
}
