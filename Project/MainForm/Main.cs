using FifaLib;
using FifaLib.Models;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace MainForm {
    public partial class Main : Form {

        private Gender currentGender;
        private Language currentLlanguage;
        private DataSource currentDatasource;
        private readonly string title = "Favourite representation";



        private List<Player> loadedPlayers;
        private List<Player> favoritePlayers;
        private List<Player> otherPlayers;
        private Player? selectedPlayer;

        public Main() {
            currentDatasource = DataSource.API;
            InitializeComponent();
        }

        private void ValidateForm() {
            if (!Repo.Instance.AppSettingExists()) {
                Settings settings = new Settings();
                settings.ShowDialog();
            }
            try {
                AppSettingsData ads = Repo.instance.GetAppSettings();
                currentLlanguage = ads.language;
                currentGender = ads.gender;
                currentDatasource = ads.source;

                gbRepresentation.Text = $"{title} ({currentGender})";
            }
            catch (Exception) {
                MessageBox.Show("Settings are invalid or corupted.\nSettings must be set again.", "Settings error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Repo.instance.DestroySettings();
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
            var teams = await Repo.instance.FetchTeams(currentGender, currentDatasource);

            teams.ForEach(x => { cbxRepresentation.Items.Add($"{x.Country}({x.FifaCode})"); });
            cbxRepresentation.SelectedIndex = 0;
        }

        private async void SetPlayerSelectionList() {
            loadedPlayers = await Repo.instance.FetchPlayers(currentGender, currentDatasource, GetFilter());
            lbxAllPlayers.Items.Clear();
            loadedPlayers.ForEach(player => {
                lbxAllPlayers.Items.Add(player.ToDisplay());
            });
            otherPlayers = new List<Player>(loadedPlayers);
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
            SetRankEvents();
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

            var imgPath = Repo.instance.GetImagePath(selectedPlayer);

            if (Repo.instance.GetImagePath(selectedPlayer).Item2) {
                playerViewerControl1.SetPicture(Repo.instance.GetImagePath(selectedPlayer).Item1);
            }
            else {
                playerViewerControl1.SetPicture(Properties.Resources.no_image_2);
            }
        }

        private void btnAddImage_Click(object sender, EventArgs e) {
            if (selectedPlayer == null) {
                MessageBox.Show("No player selected", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try {
                string path = playerViewerControl1.LoadPictureFromFile();
                Repo.instance.SaveImage(path, selectedPlayer);
            }
            catch (Exception) {
                MessageBox.Show("Image load or save failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e) {
            DialogResult result = MessageBox.Show("Do you really want exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) {
                Dispose();
            }
            else if (result == DialogResult.No) {
                e.Cancel = true;
            }
        }

        private void lbxAllPlayers_DoubleClick(object sender, EventArgs e) {
            var data = lbxAllPlayers.SelectedItem;
            if (data == null) return;

            int shirtNum = int.Parse(data.ToString().Split('(')[1].Split(')')[0]);
            var movedPlayer = loadedPlayers.Find(p => p.ShirtNumber == shirtNum);

            if (favoritePlayers.Contains(movedPlayer)) return;

            favoritePlayers.Add(movedPlayer);
            otherPlayers.Remove(movedPlayer);


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

        private async void SetRankEvents() {
            var data = await Repo.instance.FetchEvents(currentGender, currentDatasource, GetFilter());
            var dataFilterd = data.FindAll(p => (p.TypeOfEvent == "yellow-card") || (p.TypeOfEvent == "goal"));

            var dataSorted = dataFilterd.GroupBy(e => e.PlayerName).Select(g => new {
                Type = g.Key,
                Goals = g.Count(g => g.TypeOfEvent == "goal"),
                YellowCards = g.Count(g => g.TypeOfEvent == "yellow-card")
            }).ToList();



            flpEvents.Controls.Clear();
            dataSorted.ForEach(g => {
                PlayerViewerSmallControll pv = new PlayerViewerSmallControll();
                pv.SetData(g.Type, g.Goals, g.YellowCards);
                flpEvents.Controls.Add(pv);
            });
        }

        private void lbxOthers_MouseDown(object sender, MouseEventArgs e) {
            lbxFavourites.AllowDrop = !(lbxFavourites.Items.Count >= 3);
            if (lbxOthers.SelectedItems.Count >= 1) {

                if (lbxOthers.SelectedItem != null) {
                    lbxOthers.DoDragDrop(lbxOthers.SelectedItem.ToString(), DragDropEffects.Copy);
                    lbxOthers.SelectedItem = null;
                }
            }
        }

        private void lbxFavourites_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.Text)) e.Effect = DragDropEffects.Copy;
            else e.Effect = DragDropEffects.None;
        }

        private void lbxFavourites_DragDrop(object sender, DragEventArgs e) {
            if (lbxOthers.SelectedItem != null) {
                var movedItem = e.Data.GetData(DataFormats.Text);

                lbxFavourites.Items.Add(movedItem);
                lbxOthers.Items.Remove(movedItem);

                var movedPlayer = loadedPlayers.Find(p => p.ShirtNumber == int.Parse(movedItem.ToString().Split('(')[1].Split(')')[0]));
                movedPlayer.IsFavourite = true;

                favoritePlayers.Add(movedPlayer);
                otherPlayers.Remove(movedPlayer);
            }
        }

        private void lbxFavourites_MouseDown(object sender, MouseEventArgs e) {
            if (lbxFavourites.SelectedItems.Count >= 1) {

                if (lbxFavourites.SelectedItem != null) {
                    lbxFavourites.DoDragDrop(lbxFavourites.SelectedItem.ToString(), DragDropEffects.Copy);
                    lbxFavourites.SelectedItem = null;
                }
            }
        }

        private void lbxOthers_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.Text)) e.Effect = DragDropEffects.Copy;
            else e.Effect = DragDropEffects.None;
        }

        private void lbxOthers_DragDrop(object sender, DragEventArgs e) {
            if (lbxFavourites.SelectedItem != null) {
                var movedItem = e.Data.GetData(DataFormats.Text);

                lbxOthers.Items.Add(movedItem);
                lbxFavourites.Items.Remove(movedItem);

                var movedPlayer = loadedPlayers.Find(p => p.ShirtNumber == int.Parse(movedItem.ToString().Split('(')[1].Split(')')[0]));
                movedPlayer.IsFavourite = false;

                otherPlayers.Add(movedPlayer);
                favoritePlayers.Remove(movedPlayer);
            }
        }

        private void lbxFavourites_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void lbxOthers_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void lbxOthers_Click(object sender, EventArgs e) {
            var data = lbxOthers.SelectedItem;
            if (data == null) return;

            int shirtNum = int.Parse(data.ToString().Split('(')[1].Split(')')[0]);
            FillPlayerViewer(shirtNum, otherPlayers);
        }

        private void lbxFavourites_Click(object sender, EventArgs e) {
            var data = lbxFavourites.SelectedItem;
            if (data == null) return;

            int shirtNum = int.Parse(data.ToString().Split('(')[1].Split(')')[0]);
            FillPlayerViewer(shirtNum, favoritePlayers);
        }
    }
}
