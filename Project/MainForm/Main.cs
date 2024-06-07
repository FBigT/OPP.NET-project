using FifaLib;
using FifaLib.Models;
using System.Text;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace MainForm {
    public partial class Main : Form {

        private Gender currentGender;
        private Language currentLlanguage;
        private readonly string appData = "appSettings.txt";
        private readonly string title = "Favourite representation";

        private List<Player> loadedPlayers;
        private List<Player> favoritePlayers;
        private List<Player> otherPlayers;
        private Player? selectedPlayer;

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

                label1.Text = $"{title} ({currentGender})";
            }
            catch (Exception) {
                MessageBox.Show("Settings are invalid or corupted.\nSettings must be set again.", "Settings error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                File.Delete(appData);
                Dispose();
            }
        }

        private void Main_Load(object sender, EventArgs e) {
            favoritePlayers = new List<Player>();
            loadedPlayers = new List<Player>();

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
            loadedPlayers = await repo.FetchPlayers(currentGender, DataSource.API, GetFilter());
            cblPlayers.Items.Clear();
            loadedPlayers.ForEach(player => {
                cblPlayers.Items.Add(player.ToDisplay());
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

        private void btnSelect_Click(object sender, EventArgs e) {
            if (cblPlayers.CheckedItems.Count > 3) {
                MessageBox.Show("Maximum limit of 3 favourite players exceeded", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var dataChecked = cblPlayers.CheckedItems;

            favoritePlayers.Clear();
            otherPlayers = new List<Player>(loadedPlayers);

            foreach (var playerString in dataChecked) {
                int shirtNum = int.Parse(playerString.ToString().Split('(')[1].Split(')')[0]);
                favoritePlayers.Add(loadedPlayers.Find(p => p.ShirtNumber == shirtNum));
            }

            favoritePlayers.ForEach(player => {
                otherPlayers.Remove(player);

            });

            SetDisplayLists();
        }

        private void SetDisplayLists() {
            lbxFavourites.Items.Clear();
            lbxOthers.Items.Clear();

            favoritePlayers.ForEach(player => {
                lbxFavourites.Items.Add(player.ToDisplay());
                player.IsFavourite = true;
            });

            otherPlayers.ForEach(player => {
                lbxOthers.Items.Add(player.ToDisplay());
            });
        }

        private void lbxFavourites_DoubleClick(object sender, EventArgs e) {
            var data = lbxFavourites.SelectedItem;
            if (data == null) return;

            int shirtNum = int.Parse(data.ToString().Split('(')[1].Split(')')[0]);
            FillPlayerViewer(shirtNum, favoritePlayers);
        }

        private void lbxOthers_DoubleClick(object sender, EventArgs e) {
            var data = lbxOthers.SelectedItem;
            if (data == null) return;

            int shirtNum = int.Parse(data.ToString().Split('(')[1].Split(')')[0]);
            FillPlayerViewer(shirtNum, otherPlayers);
        }

        private void FillPlayerViewer(int shirtNum, List<Player> players) {
            selectedPlayer = players.Find(p => p.ShirtNumber == shirtNum);

            playerViewerControl1.FillView(selectedPlayer);

            if (File.Exists(selectedPlayer.PicturePath)) {
                playerViewerControl1.SetPicture(selectedPlayer.PicturePath);
            }
            else {
                playerViewerControl1.SetPicture(Properties.Resources.no_image_2);
            }
        }

        private void btnAddImage_Click(object sender, EventArgs e) {
            string path = playerViewerControl1.LoadPictureFromFile();

            if (string.IsNullOrEmpty(path)) return;

            selectedPlayer.SetPicturePath(path);
        }
    }
}
