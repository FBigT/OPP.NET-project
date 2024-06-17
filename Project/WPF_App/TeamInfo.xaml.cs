using FifaLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_App {
    /// <summary>
    /// Interaction logic for TeamInfo.xaml
    /// </summary>
    public partial class TeamInfo : Window {
        public TeamInfo() {
            InitializeComponent();
        }

        public void SetInfo(TeamResults t) {
            // info
            lblCode.Content = t.FifaCode;
            lblTeam.Content = t.Country;

            //goals
            lblFailed.Content = t.GoalsAgainst;
            lblDif.Content = t.GoalDifferential;
            lblScore.Content = t.GoalsFor;

            //games
            lblLost.Content = t.Losses;
            lblDraw.Content = t.Draws;
            lblPlayed.Content = t.GamesPlayed;
            lblWon.Content = t.Wins;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {

        }

        public void SwitchLanguage(Language l) {
            switch (l) {
                case FifaLib.Models.Language.English:
                    _LTeam.Content = "Team";
                    _LCode.Content = "Code";
                    _LPlayedGames.Content = "Played games";
                    _LWonGames.Content = "Won games";
                    _LLostGames.Content = "Lost games";
                    _LDraws.Content = "Draws";
                    _LScoredGoals.Content = "Scored goals";
                    _LLostGoals.Content = "Lost goals";
                    _LGoalDifference.Content = "Goal difference";

                    break;
                case FifaLib.Models.Language.Croatian:
                    _LTeam.Content = "Tim";
                    _LCode.Content = "Kod";
                    _LPlayedGames.Content = "Odigrane igre";
                    _LWonGames.Content = "Pobjeđene igre";
                    _LLostGames.Content = "Izgubljene igre";
                    _LDraws.Content = "Neriješeno";
                    _LScoredGoals.Content = "Postignuti golovi";
                    _LLostGoals.Content = "Izgubljeni golovi";
                    _LGoalDifference.Content = "Gol razlika";
                    break;
                default:
                    break;
            }
        }
    }
}
