using FifaLib;
using FifaLib.Models;
using iTextSharp.text.pdf;
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

        private bool loading = false;
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

            Repo.Instance.SetDataFilter(currentChampionship);
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

        private void SetLocalization() {
            if (currentLlanguage == Language.Croatian) {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("hr");
            }
            else {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-GB");
            }
            Controls.Clear();
            InitializeComponent();
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

                SetLocalization();
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

        private async void SetPlayerSelectionList(bool skip) {
            lbxAllPlayers.Items.Clear();

            if (!skip || open == 0) {
                loadedPlayers = await Repo.Instance.FetchPlayers(currentGender, currentDatasource, currentChampionship);
                favoritePlayers.Clear();
                otherPlayers = new List<Player>(loadedPlayers);
            }

            lbxFavourites.Items.Clear();
            loadedPlayers.ForEach(player => {
                lbxAllPlayers.Items.Add(player.ToDisplay());
            });


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
            if (settingsForm.ShowDialog() == DialogResult.OK) {
                loading = true;
                ValidateForm();
                SetRepresentationCbx();
                SetDisplayLists();
                if (selectedPlayer != null)
                    FillPlayerViewer(selectedPlayer);
                loading = true;
            }
        }


        private void cbxRepresentation_SelectedIndexChanged(object sender, EventArgs e) {
            currentChampionship = SetFilter();
            SetPlayerSelectionList(loading);
            SetRankEvents();
            SetVisitors();

            if (open == 0) open++;
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

        private void FillPlayerViewer(Player selected) {
            playerViewerControl1.FillView(selected);

            var imgPath = Repo.Instance.GetImagePath(selected);

            if (Repo.Instance.GetImagePath(selected).Item2) {
                playerViewerControl1.SetPicture(Repo.Instance.GetImagePath(selected).Item1);
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

                //if (playerViewerControl1.GetImage() != Properties.Resources.no_image_2) {
                //    playerViewerControl1.SetPicture(Properties.Resources.no_image_2);
                //    FillEventPanel(true, Properties.Resources.no_image_2, selectedPlayer);
                //}

                try {
                    string savedPath = Repo.Instance.SaveImage(path, selectedPlayer);

                    playerViewerControl1.SetPicture(savedPath);
                    FillEventPanel(true, Image.FromFile(savedPath), selectedPlayer);
                }
                catch (Exception) {
                    MessageBox.Show("Cant set another image.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
                    Player? found = loadedPlayers.Find(p => p.Name == pcvs.GetName());
                    (string? path, bool did) = Repo.Instance.GetImagePath(found);
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
                    return false;
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
            if (printDialog.ShowDialog() == DialogResult.OK) {
                try {
                    printDocument.Print();
                }
                catch (Exception) {
                    MessageBox.Show("Print failed", "Print", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnMargins_Click(object sender, EventArgs e) {
            pageSetupDialog.ShowDialog();
        }

        private void btnPreview_Click(object sender, EventArgs e) {
            printPreviewDialog.ShowDialog(this);
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e) {
            var x = e.MarginBounds.Left;
            var y = e.MarginBounds.Top;
            Bitmap bmap = new Bitmap(gbRankigs.Width, gbRankigs.Height);

            gbRankigs.DrawToBitmap(bmap, new Rectangle {
                X = 0,
                Y = 0,
                Width = bmap.Width,
                Height = bmap.Height
            });

            e.Graphics?.DrawImage(bmap, x, y);
        }
    }
}
