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
        private readonly string appData = "appSettings.txt";
        private readonly string title = "Favourite representation";

        private readonly string playerImagePath;

        private List<Player> loadedPlayers;
        private List<Player> favoritePlayers;
        private List<Player> otherPlayers;
        private Player? selectedPlayer;

        private readonly Repo repo;

        public Main() {
            repo = new Repo();
            currentDatasource = DataSource.API;
            playerImagePath = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + @"\Assets\PlayerImages";
            CreateAssetDir();
            InitializeComponent();
        }

        private void CreateAssetDir() {
            if (!Directory.Exists(playerImagePath)) {
                Directory.CreateDirectory(playerImagePath);               
            }
        }

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
                currentDatasource = (DataSource)Enum.Parse(typeof(DataSource), lines[2]);

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
            var teams = await repo.FetchTeams(currentGender, currentDatasource);

            teams.ForEach(x => { cbxRepresentation.Items.Add($"{x.Country}({x.FifaCode})"); });
            cbxRepresentation.SelectedIndex = 0;
        }

        private async void SetPlayerSelectionList() {
            loadedPlayers = await repo.FetchPlayers(currentGender, currentDatasource, GetFilter());
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

            var files = System.IO.Directory.GetFiles(playerImagePath, selectedPlayer.Name + ".*");
            if (files.Length > 0) {
                playerViewerControl1.SetPicture(files[0]);
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
                string extension = Path.GetExtension(path);
                string copyPath = Path.Combine(playerImagePath, selectedPlayer.Name + extension);
                File.Copy(path, copyPath, true);
            }
            catch (Exception) {
                MessageBox.Show("Image load or save failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbxFavourites_MouseDown(object sender, MouseEventArgs e) {
            if (lbxFavourites.Items.Count >= 1) {
                if (lbxFavourites.SelectedItem != null) {
                    lbxFavourites.DoDragDrop(lbxFavourites.SelectedItem.ToString(), DragDropEffects.Copy);
                }
            }
        }

        private void lbxOthers_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.Text)) e.Effect = DragDropEffects.Copy;
            else e.Effect = DragDropEffects.None;
        }

        private void lbxOthers_DragDrop(object sender, DragEventArgs e) {
            lbxOthers.Items.Add(e.Data.GetData(DataFormats.Text));
            lbxFavourites.Items.Remove(e.Data.GetData(DataFormats.Text));
        }

        private void lbxOthers_MouseDown(object sender, MouseEventArgs e) {
            if (lbxOthers.Items.Count >= 1) {
                if (lbxOthers.SelectedItem != null) {
                    lbxOthers.DoDragDrop(lbxOthers.SelectedItem.ToString(), DragDropEffects.Copy);
                }
            }
        }

        private void lbxFavourites_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.Text)) e.Effect = DragDropEffects.Copy;
            else e.Effect = DragDropEffects.None;
        }
        private void lbxFavourites_DragDrop(object sender, DragEventArgs e) {
            lbxFavourites.Items.Add(e.Data.GetData(DataFormats.Text));
            lbxOthers.Items.Remove(e.Data.GetData(DataFormats.Text));
        }

        private bool DragDropMD(ListBox lb) {
            if (lb.Items.Count >= 1) {
                if (lb.SelectedItem != null) {
                    lb.DoDragDrop(lb.SelectedItem.ToString(), DragDropEffects.Copy);
                    return true;
                }
            }
            return false;
        }

        private bool PreformDrop(ListBox from, ListBox to, DragEventArgs e) {

            to.Items.Add(e.Data.GetData(DataFormats.Text));
            from.Items.Remove(e.Data.GetData(DataFormats.Text));



            return false;
        }

    }
}
