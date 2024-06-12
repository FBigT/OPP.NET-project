using FifaLib;
using FifaLib.Models;
using MainForm.Properties;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace MainForm {
    public partial class Main : Form {

        private Gender currentGender;
        private Language currentLlanguage;
        private DataSource currentDatasource;
        private readonly string title = "Favourite representation";

        private List<TeamResults> loadedTeams;

        private List<GameEvent> loadedGameEvents;

        private List<Visitor> loadedVisitors;

        private List<Player> loadedPlayers;
        private List<Player> favoritePlayers;
        private List<Player> otherPlayers;
        private Player? selectedPlayer;

        private string? currentChampionship;

        private int open = 0;

        public Main() {
            currentDatasource = DataSource.API;
            InitializeComponent();
        }

        private async void Main_Load(object sender, EventArgs e) {
            favoritePlayers = new List<Player>();
            loadedPlayers = new List<Player>();

            ValidateForm();

            try {
                loadedTeams = await Repo.Instance.FetchTeams(currentGender, currentDatasource);
            }
            catch (Exception) {
                SaveFavourites();
            }

            if (Repo.Instance.UserSettingExists()) {
                try {
                    currentChampionship = Repo.Instance.GetUserSettings().champoinship;
                }
                catch (Exception) {
                    MessageBox.Show("Settings are invalid or corupted.\nSettings must be set again.", "Settings error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Repo.Instance.DestroyUserSettings();
                }
            }
            else {
               loadedTeams.Sort((x, y) => x.FifaCode.CompareTo(y.FifaCode));
               currentChampionship = loadedTeams.ToArray()[0].FifaCode;
            }

            SetRepresentationCbx();

            loadedVisitors = await Repo.Instance.FetchVisitors(currentGender, currentDatasource, currentChampionship);

            try {
                loadedPlayers = await Repo.Instance.FetchPlayers(currentGender, currentDatasource, currentChampionship);
            }
            catch (Exception) {
                MessageBox.Show("Failed to load data.", "Data error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadFavs();
        }

        private void ValidateForm() {
            if (!Repo.Instance.AppSettingExists()) {
                Settings settings = new Settings();
                settings.ShowDialog();
            }
            try {
                AppSettingsData ads = Repo.Instance.GetAppSettings();
                currentLlanguage = ads.language;
                currentGender = ads.gender;
                currentDatasource = ads.source;

                gbRepresentation.Text = $"{title} ({currentGender})";
            }
            catch (Exception) {
                MessageBox.Show("Settings are invalid or corupted.\nSettings must be set again.", "Settings error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Repo.Instance.DestroySettings();
                Dispose();
            }
        }
        private void LoadFavs() {
            try {
                UserSettingsData usd = Repo.Instance.GetUserSettings();

                for (int i = 0; i < usd.faves.Length; i++) {
                    var fp = otherPlayers.Find(x => x.Name == usd.faves[i]);

                    if (fp != null) {
                        otherPlayers.Remove(fp);
                        lbxOthers.Items.Remove(fp.ToDisplay());

                        fp.IsFavourite = true;
                        favoritePlayers.Add(fp);
                        lbxFavourites.Items.Add(fp.ToDisplay());

                    }
                }
            }
            catch (Exception) {
                MessageBox.Show("Settings are invalid or corupted.\nSettings must be set again.", "Settings error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Repo.Instance.DestroyUserSettings();
            }
        }

        private void SetRepresentationCbx() {
            cbxRepresentation.Items.Clear();

            loadedTeams.ForEach(x => cbxRepresentation.Items.Add(x.ToDisplay()));

            if (Repo.Instance.UserSettingExists()) {
                try {
                    var found = loadedTeams.Find(x => x.FifaCode == currentChampionship);

                    cbxRepresentation.SelectedIndex = cbxRepresentation.FindStringExact($"{found.Country}({found.FifaCode})");
                }
                catch (Exception) {
                    MessageBox.Show("User settings are invalid or corupted.\nUser settings must be set again.", "Settings error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Repo.Instance.DestroyUserSettings();
                    Dispose();
                }
            }
            else {
                Repo.Instance.SaveUserSettings(currentChampionship, false);
                cbxRepresentation.SelectedIndex = 0;
            }
        }

        private async void SetPlayerSelectionList() {
            lbxAllPlayers.Items.Clear();

            loadedPlayers = await Repo.Instance.FetchPlayers(currentGender, currentDatasource, currentChampionship);

            lbxFavourites.Items.Clear();
            favoritePlayers.Clear();

            loadedPlayers.ForEach(player => {
                lbxAllPlayers.Items.Add(player.ToDisplay());
            });
            otherPlayers = new List<Player>(loadedPlayers);

            lbxOthers.Items.Clear();
            otherPlayers.ForEach(p => {
                lbxOthers.Items.Add(p.ToDisplay());
            });
        }

        private string SetFilter() {
            var item = cbxRepresentation.SelectedItem;

            if (item == null) {
                item = cbxRepresentation.Items[0];
                return item.ToString().Split('(')[1].Split(')')[0];
            }

            return item.ToString().Split('(')[1].Split(')')[0];
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e) {
            Settings settingsForm = new Settings();
            settingsForm.ShowDialog();
            ValidateForm();
            SetRepresentationCbx();
        }


        private void cbxRepresentation_SelectedIndexChanged(object sender, EventArgs e) {
            currentChampionship = SetFilter();

            SetPlayerSelectionList();
            SetRankEvents();
            SetVisitors();

            if (open >= 1) {
                SaveFavourites();
            }
            else {
                open++;
            }
        }

        private async void SetVisitors() {
            loadedVisitors = await Repo.Instance.FetchVisitors(currentGender, currentDatasource, currentChampionship);

            flpVisitors.Controls.Clear();
            loadedVisitors.ForEach(v => {
                VisitorViewrControl vvc = new VisitorViewrControl();

                vvc.SetText(v.Location, v.Attendance.ToString(), v.HomeTeamCountry, v.AwayTeamCountry);

                flpVisitors.Controls.Add(vvc);
            });
        }

        private void FillPlayerViewer(int shirtNum, List<Player> players) {
            selectedPlayer = players.Find(p => p.ShirtNumber == shirtNum);

            playerViewerControl1.FillView(selectedPlayer);

            var imgPath = Repo.Instance.GetImagePath(selectedPlayer);

            if (Repo.Instance.GetImagePath(selectedPlayer).Item2) {
                playerViewerControl1.SetPicture(Repo.Instance.GetImagePath(selectedPlayer).Item1);
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
                if (path == string.Empty) return;

                FillEventPanel(true, Image.FromFile(path), selectedPlayer);
                Repo.Instance.SaveImage(path, selectedPlayer);
            }
            catch (Exception) {
                MessageBox.Show("Image save failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void SaveFavourites() {
            string[] favPlayerNames = new string[favoritePlayers.Count];
            if (favPlayerNames.Length == 0) {
                Repo.Instance.SaveUserSettings(currentChampionship, true);
            }
            for (int i = 0; i < favPlayerNames.Length; i++) {
                favPlayerNames[i] = favoritePlayers.ToArray()[i].Name;
            }
            Repo.Instance.SaveUserSettings(currentChampionship, false, favPlayerNames);
        }

        private void lbxAllPlayers_DoubleClick(object sender, EventArgs e) {
            if (favoritePlayers.Count >= 3) return;

            var data = lbxAllPlayers.SelectedItem;
            if (data == null) return;

            int shirtNum = int.Parse(data.ToString().Split('(')[1].Split(')')[0]);
            var movedPlayer = otherPlayers.Find(p => p.ShirtNumber == shirtNum);

            if (movedPlayer == null) return;

            favoritePlayers.Add(movedPlayer);
            if (otherPlayers.Remove(movedPlayer)) {
                var a = 1;
            }

            SaveFavourites();

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
            loadedGameEvents = await Repo.Instance.FetchEvents(currentGender, currentDatasource, currentChampionship);
            var dataFilterd = loadedGameEvents.FindAll(p => (p.TypeOfEvent == "yellow-card") || (p.TypeOfEvent == "goal"));

            var dataSorted = dataFilterd.GroupBy(e => e.PlayerName).Select(g => new {
                Type = g.Key,
                Goals = g.Count(g => g.TypeOfEvent == "goal"),
                YellowCards = g.Count(g => g.TypeOfEvent == "yellow-card")
            }).ToList();

            flpEvents.Controls.Clear();
            dataSorted.ForEach(g => {
                PlayerViewerSmallControll pv = new PlayerViewerSmallControll();
                pv.SetData(g.Type, g.Goals, g.YellowCards);
                pv.Name = g.Type;

                (string path, bool did) = Repo.Instance.GetImagePath(loadedPlayers.Find(p => p.Name == g.Type));

                if (did) pv.SetImage(Image.FromFile(path));
                else pv.SetImage(Properties.Resources.no_image_2);

                flpEvents.Controls.Add(pv);
            });

            FillEventPanel(false);
        }

        private bool FillEventPanel(bool overload, Image? image = null, Player? p = null) {
            if (!overload) {
                foreach (PlayerViewerSmallControll pcvs in flpEvents.Controls) {
                    (string path, bool did) = Repo.Instance.GetImagePath(loadedPlayers.Find(p => p.Name == pcvs.GetName()));
                    if (did) {
                        pcvs.SetImage(Image.FromFile(path));
                    }
                    else {
                        pcvs.SetImage(Properties.Resources.no_image_2);
                    }
                }
                return true;
            }
            else if (p != null && image != null) {
                try {
                    var data = (PlayerViewerSmallControll)flpEvents.Controls.Find(p.Name, false)[0];
                    data.SetImage(image);
                }
                catch (Exception) {

                }
                return true;
            }
            return false;
        }

        private void lbxOthers_MouseDown(object sender, MouseEventArgs e) {
            lbxFavourites.AllowDrop = !(lbxFavourites.Items.Count >= 3);
            if (lbxOthers.SelectedItems.Count >= 1) {

                var data = lbxOthers.SelectedItem;
                if (data == null) return;

                int shirtNum = int.Parse(data.ToString().Split('(')[1].Split(')')[0]);
                FillPlayerViewer(shirtNum, otherPlayers);

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

                var movedPlayer = otherPlayers.Find(p => p.ShirtNumber == int.Parse(movedItem.ToString().Split('(')[1].Split(')')[0]));
                movedPlayer.IsFavourite = true;

                favoritePlayers.Add(movedPlayer);
                otherPlayers.Remove(movedPlayer);

                SaveFavourites();
            }
        }

        private void lbxFavourites_MouseDown(object sender, MouseEventArgs e) {
            if (lbxFavourites.SelectedItems.Count >= 1) {

                var data = lbxFavourites.SelectedItem;
                if (data == null) return;

                int shirtNum = int.Parse(data.ToString().Split('(')[1].Split(')')[0]);
                FillPlayerViewer(shirtNum, favoritePlayers);

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

                var movedPlayer = favoritePlayers.Find(p => p.ShirtNumber == int.Parse(movedItem.ToString().Split('(')[1].Split(')')[0]));
                movedPlayer.IsFavourite = false;

                otherPlayers.Add(movedPlayer);
                favoritePlayers.Remove(movedPlayer);

                SaveFavourites();
            }
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

        private void btnPrint_Click(object sender, EventArgs e) {
            printPreviewDialog1.Document = printDocument1;
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK) {
                printDocument1.Print();
            }


        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e) {

        }

        private void flpEvents_Click(object sender, EventArgs e) {
            //var a = flpEvents.Controls.
        }
    }
}
