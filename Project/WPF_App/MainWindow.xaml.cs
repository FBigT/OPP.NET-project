using FifaLib;
using FifaLib.Models;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_App {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        AppSettingsData appSettingsData;
        UserSettingsData userSettingsData;
        private List<Match> matches = new List<Match>();
        private SortedSet<string> others = new SortedSet<string>();
        private List<TeamResults> teamResults = new List<TeamResults>();

        private List<Player> homePlayers = new List<Player>();
        private List<Player> opposerPlayers = new List<Player>();

        private Match? foundMatch;

        private bool otherToggle = true;

        private TeamInfo teamInfoHome;
        private TeamInfo teamInfoAway;

        private string opposingCode = string.Empty;

        private bool errorClose = false;

        private bool loaded = false;

        public MainWindow() {
            InitializeComponent();
            SetFancy();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e) {
            await Reload();
        }

        private async Task Reload() {
            Load();
            SwitchLanguage(appSettingsData.language);
            await GetMatches();
            await GetTeams();
            SetCBX();
            await GetPlayers();
            foundMatch = FindMatch();
            await GetEvents();
            SetData();
            SetPlayersToDisplay(homePlayers, opposerPlayers);
        }

        private void Load() {
            try {
                if (Repo.Instance.AppSettingExists()) {
                    appSettingsData = Repo.Instance.GetAppSettings();
                }
                else {
                    Settings s = new Settings();
                    s.ShowDialog();
                    appSettingsData = Repo.Instance.GetAppSettings();
                }
                if (Repo.Instance.UserSettingExists()) {
                    userSettingsData = Repo.Instance.GetUserSettings();
                }
            }
            catch (Exception) {
                MessageBox.Show("An error acured while loading app setings.\nApp will have to be restarted.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Repo.Instance.DestroySettings();
                errorClose = true;
                Close();
            }

            var size = ResolutionReder.ResolutionToIntArray(appSettingsData.resolution);

            SetResolution(size);
        }

        private void SetResolution(int[] size) {
            if (size[0] == 0 && size[1] == 0) {
                WindowStyle = WindowStyle.None;
                WindowState = WindowState.Maximized;
            }
            else {
                WindowStyle = WindowStyle.SingleBorderWindow;
                WindowState = WindowState.Normal;
                Width = size[0];
                Height = size[1];
            }
        }

        private async Task GetTeams() {

            try {
                teamResults = await Repo.Instance.FetchTeams(appSettingsData.gender, appSettingsData.source);
            }
            catch (Exception) {
                MessageBox.Show("An error acured while fetching data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task GetMatches() {

            try {
                matches = await Repo.Instance.FetchMatches(appSettingsData.gender, appSettingsData.source, userSettingsData.champoinship);
            }
            catch (Exception) {
                MessageBox.Show("An error acured while fetching data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            matches.ForEach(m =>{
                if (m.HomeTeam.Code == userSettingsData.champoinship) {
                    others.Add(m.AwayTeam.Code);
                }
                else {
                    others.Add(m.HomeTeam.Code);
                }
            });
        }

        private async Task GetPlayers() {
            try {
                opposingCode = cbxOpposers.SelectedItem.ToString();

                homePlayers = Repo.Instance.ExtractPlayersFromMatches(matches, userSettingsData.champoinship, opposingCode, false);
                opposerPlayers = Repo.Instance.ExtractPlayersFromMatches(matches, userSettingsData.champoinship, opposingCode, true);
            }
            catch (Exception) {
                MessageBox.Show("An error acured while fetching data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private struct PlayerData {
            public string Name;
            public int Goals;
            public int Yellows;

            public PlayerData(string name, int goals, int yellows) {
                Name = name;
                Goals = goals;
                Yellows = yellows;
            }
        }

        private List<PlayerData> eventsHome = new List<PlayerData>();
        private List<PlayerData> eventsAway = new List<PlayerData>();

        private async Task GetEvents() {
            var ea = await Repo.Instance.FetchEvents(appSettingsData.gender, appSettingsData.source, userSettingsData.champoinship, foundMatch, false);
            var eh = await Repo.Instance.FetchEvents(appSettingsData.gender, appSettingsData.source, cbxOpposers.SelectedItem.ToString(), foundMatch, true);
            
            eventsHome.AddRange(SortEventsToPlayers(eh));
            eventsAway.AddRange(SortEventsToPlayers(ea));
        }

        private List<PlayerData> SortEventsToPlayers(List<GameEvent> events) {
            var dataFilterd = events.FindAll(p => (p.TypeOfEvent == "yellow-card") || (p.TypeOfEvent == "goal"));

            var dataSorted = dataFilterd.GroupBy(e => e.PlayerName).Select(g => new {
                Type = g.Key,
                Goals = g.Count(g => g.TypeOfEvent == "goal"),
                YellowCards = g.Count(g => g.TypeOfEvent == "yellow-card")
            }).ToList();

            List<PlayerData> players = new List<PlayerData>();

            dataSorted.ForEach(d => {
                players.Add(new PlayerData(d.Type, d.Goals, d.YellowCards));
            });

            return players;
        }

        private void SetCBX() {
            cbxOpposers.Items.Clear();
            foreach (var item in others) {
                cbxOpposers.Items.Add(item);
            }
            if (!loaded) {
                cbxOpposers.SelectedIndex = 0;
            }
        }

        private Match? FindMatch() {
            var o = cbxOpposers.SelectedItem.ToString();

            if (o == null) {
                return null;
            }

            var found = matches.Find(m => m.AwayTeam.Code == o);

            if (found == null) {
                found = matches.Find(m => m.HomeTeam.Code == o);
            }

            return found;
        }

        private void SetData() {

            if (foundMatch == null) return;

            if (foundMatch.HomeTeam.Code == userSettingsData.champoinship) {
                lblFav.Content = foundMatch.HomeTeam.Country;
                lblOther.Content = foundMatch.AwayTeam.Country;

                lblHomeScore.Content = foundMatch.HomeTeam.Goals;
                lblAwayScore.Content = foundMatch.AwayTeam.Goals;
            }
            else {
                lblFav.Content = foundMatch.AwayTeam.Country;
                lblOther.Content = foundMatch.HomeTeam.Country;

                lblHomeScore.Content = foundMatch.AwayTeam.Goals;
                lblAwayScore.Content = foundMatch.HomeTeam.Goals;
            }
            
            lblTime.Content = foundMatch.Datetime.ToString("HH:mm");
            lblDate.Content = foundMatch.Datetime.Date;

        }

        private void SetFancy() {
            gOthers.Height = 0;
            gOthers.Visibility = Visibility.Visible;
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e) {
            Settings s = new Settings();
            s.ShowDialog();

            if (s.DialogResult == true) {
                if (s.ResetRequired) {
                    MessageBox.Show("Application must restart for changes to take effect.", "Restart", MessageBoxButton.OK, MessageBoxImage.Information);
                    string applicationPath = Process.GetCurrentProcess().MainModule.FileName;
                    Process.Start(applicationPath);
                    Environment.Exit(0);
                }
                Load();
                SwitchLanguage(appSettingsData.language);
            }
        }

        private void btnOthers_Click(object sender, RoutedEventArgs e) {
            var dHeight = 105;
            CircleEase ce = new CircleEase() { EasingMode = EasingMode.EaseOut};


            if (otherToggle) {
                DoubleAnimation doubleAnimation = new DoubleAnimation(dHeight, new Duration(TimeSpan.FromSeconds(.3))) { AccelerationRatio = .5, EasingFunction = ce};
                gOthers.BeginAnimation(HeightProperty, doubleAnimation);
            }
            else {
                DoubleAnimation doubleAnimation = new DoubleAnimation(0, new Duration(TimeSpan.FromSeconds(.2))) { AccelerationRatio = .7 , EasingFunction = ce };
                gOthers.BeginAnimation(HeightProperty, doubleAnimation);
            }
            otherToggle = !otherToggle;
        }

        private async void cbxOpposers_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            await GetMatches();

            foundMatch = FindMatch();
            if (loaded) {
                await GetPlayers();
                await GetEvents();
                SetData();
                SetPlayersToDisplay(homePlayers, opposerPlayers);
            }
            loaded = true;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            if (errorClose) {
                teamInfoAway?.Close();
                teamInfoHome?.Close();

                Environment.Exit(0);
            }
            else {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to close the application?", "Close Application", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.No) {
                    e.Cancel = true;
                }
                else {
                    teamInfoAway?.Close();
                    teamInfoHome?.Close();
                }
            }
        }

        private void btnInfoHome_Click(object sender, RoutedEventArgs e) {
            SetTeamData((string)(sender as Button).Tag);
        }

        private void btnInfoAway_Click(object sender, RoutedEventArgs e) {
            SetTeamData((string)(sender as Button).Tag);
        }

        private void SetTeamData(string? tag = null) {
            if (tag == null) { 
                MessageBox.Show("Team tag not found.", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                return;
            }

            TeamResults? found = null;

            try {
                if (tag.ToLower() == "home") {
                    found = teamResults.Find(t => t.Country == (string)lblFav.Content);
                    if (found == null) {
                        MessageBox.Show("Team is not found.", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                        return;
                    }
                    if (btnInfoHome.IsEnabled) {
                        teamInfoHome = new TeamInfo();
                        teamInfoHome.SwitchLanguage(appSettingsData.language);

                        teamInfoHome.Closing += (sender, e) => btnInfoHome.IsEnabled = true;

                        btnInfoHome.IsEnabled = false;

                        teamInfoHome.SetInfo(found);
                        teamInfoHome.Show();
                    }
                }
                else if (tag.ToLower() == "away") {
                    found = teamResults.Find(t => t.Country == (string)lblOther.Content);
                    if (found == null) {
                        MessageBox.Show("Team is not found.", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                        return;
                    }
                    if (btnInfoAway.IsEnabled) {
                        teamInfoAway = new TeamInfo();
                        teamInfoAway.SwitchLanguage(appSettingsData.language);

                        teamInfoAway.Closing += (sender, e) => btnInfoAway.IsEnabled = true;

                        btnInfoAway.IsEnabled = false;

                        teamInfoAway.SetInfo(found);
                        teamInfoAway.Show();
                    }
                }
            }
            catch (Exception) {

            }
        }

        private void SetPlayersToDisplay(List<Player> homePlayers, List<Player> opposerPlayers) {
            ClearField();

            if (homePlayers == null || opposerPlayers == null) return;

            double scale = 1;
            double offset = 0;

            if (appSettingsData.resolution == Resolution.R_1680_1050) {
                scale = .75;
                offset = 20;
            }
            else {
                scale = 1;
                offset = 0;
            }

            homePlayers.ForEach(p => {
                switch (p.Position) {
                    case "Forward":
                        SetPlayer(p, ref pHomeMainGuy, 8, "home", scale, offset);
                        break;
                    case "Midfield":
                        SetPlayer(p, ref pHomeMid, 7, "home", scale, offset);
                        break;
                    case "Defender":
                        SetPlayer(p, ref pHomeDef, 6, "home", scale, offset);
                        break;
                    case "Goalie":
                        SetPlayer(p, ref pHomeGoalGuy, 5, "home", scale, offset);
                        break;
                    default:
                        break;
                }
            });

            opposerPlayers.ForEach(p => {
                switch (p.Position) {
                    case "Forward":
                        SetPlayer(p, ref pAwayMainGuy, 4, "away", scale, offset);
                        break;
                    case "Midfield":
                        SetPlayer(p, ref pAwayMid, 3, "away", scale, offset);
                        break;
                    case "Defender":
                        SetPlayer(p, ref pAwayDef, 2, "away", scale, offset);
                        break;
                    case "Goalie":
                        SetPlayer(p, ref pAwayGoalGuy, 1, "away", scale, offset);
                        break;
                    default:
                        break;
                }
            });

            SetFieldPanelAlingment(VerticalAlignment.Center);
        }

        private void SetPlayer(Player p, ref StackPanel sp, int v, string tag, double scale = 1, double offset = 0) {
            double space = sp.ActualWidth / 4;
            PlayerViewer playerViewer = new PlayerViewer();

            playerViewer.Height = playerViewer.Height * scale;
            playerViewer.Width = playerViewer.Width * scale;

            playerViewer.SetData(p);
            playerViewer.SetZ(v);

            playerViewer.Tag = tag;

            playerViewer.MouseDown += (sender, args) => { 
                PlayerWindow playerWindow = new PlayerWindow();

                if ((sender as PlayerViewer).Tag == "home") {

                    var found = eventsHome.Find(e => e.Name == p.Name);
                    playerWindow.SetPlayer(p, found.Goals, found.Yellows);

                    try {
                        (string path, bool did) = Repo.Instance.GetImagePath(p);

                        if (did) playerWindow.SetImage(path);
                        else playerWindow.SetImage(string.Empty);
                    }
                    catch (Exception) {

                    }
                }
                else if ((sender as PlayerViewer).Tag == "away") {

                    var found = eventsAway.Find(e => e.Name == p.Name);
                    playerWindow.SetPlayer(p, found.Goals, found.Yellows);

                    try {
                        (string path, bool did) = Repo.Instance.GetImagePath(p);

                        if (did) playerWindow.SetImage(path);
                        else playerWindow.SetImage(string.Empty);
                    }
                    catch (Exception) {

                    }
                }

                playerWindow.ShowDialog();
            };

            try {
                (string path, bool did) = Repo.Instance.GetImagePath(p);

                if (did) playerViewer.SetImage(path);
                else playerViewer.SetImage(string.Empty);
            }
            catch (Exception) {

            }

            playerViewer.setMargine(new Thickness(-space, -75 * scale + offset, -space, -75 * scale + offset));
            sp.Children.Add(playerViewer);
        }

        private void ClearField() {
            pAwayDef.Children.Clear();
            pAwayGoalGuy.Children.Clear();
            pAwayMainGuy.Children.Clear();
            pAwayMid.Children.Clear();

            pHomeDef.Children.Clear();
            pHomeGoalGuy.Children.Clear();
            pHomeMainGuy.Children.Clear();
            pHomeMid.Children.Clear();
        }

        private void SetFieldPanelAlingment(VerticalAlignment v) {
            pAwayDef.VerticalAlignment = v;
            pAwayGoalGuy.VerticalAlignment = v;
            pAwayMainGuy.VerticalAlignment = v;
            pAwayMid.VerticalAlignment = v;

            pHomeDef.VerticalAlignment = v;
            pHomeGoalGuy.VerticalAlignment = v;
            pHomeMainGuy.VerticalAlignment = v;
            pHomeMid.VerticalAlignment = v;
        }

        private void SwitchLanguage(Language l) {
            switch (l) {
                case FifaLib.Models.Language.English:
                    lblOpposingSelector.Content = "Opposing team";
                    break;
                case FifaLib.Models.Language.Croatian:
                    lblOpposingSelector.Content = "Protivnička ekipa";
                    break;
                default: 
                    break;
            }
        }
    }
}