using FifaLib;
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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window {
        AppSettingsData appSettingsData;
        UserSettingsData userSettingsData;
        private int stage = 1;
        private List<TeamResults> teams;

        public bool ResetRequired { get; private set; } = false;

        public Settings() {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e) {
            CancelStep();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e) {
            ConfirmStep();
        }

        private void cbxResolution_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            appSettingsData.resolution = ParseToEnum<Resolution>(cbxResolution.SelectedIndex);
        }

        private void cbxGender_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            appSettingsData.gender = ParseToEnum<Gender>(cbxGender.SelectedIndex);
        }

        private void cbxLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            appSettingsData.language = ParseToEnum<Language>(cbxLanguage.SelectedIndex);
        }

        private void cbxRepres_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var rep = cbxRepres.SelectedItem.ToString().Split('(')[1].Split(')')[0];
            if (rep != userSettingsData.champoinship && userSettingsData.champoinship != null) ResetRequired = true;
            userSettingsData.champoinship = rep;
        }

        private void SettingsWindows_Loaded(object sender, RoutedEventArgs e) {
            spRepres.Visibility = Visibility.Hidden;
            spSettings.Visibility = Visibility.Visible;

            btnConfirm.Content = "Next";
            btnCancel.Content = "Cancel";

            Fillcbx();
            try {
                if (Repo.Instance.AppSettingExists()) {
                    appSettingsData = Repo.Instance.GetAppSettings();

                    cbxGender.SelectedIndex = (int)appSettingsData.gender;
                    cbxLanguage.SelectedIndex = (int)appSettingsData.language;
                    cbxResolution.SelectedIndex = (int)appSettingsData.resolution;
                }
                if (Repo.Instance.UserSettingExists()) {
                    userSettingsData = Repo.Instance.GetUserSettings();

                    try {
                        var found = teams.Find(x => x.FifaCode == userSettingsData.champoinship);
                        cbxRepres.SelectedIndex = teams.IndexOf(found);
                    }
                    catch (Exception) {
                        cbxRepres.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception) {
                MessageBox.Show("An error acured while loading app setings or user settings", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Fillcbx() {
            SetCbx<Language>(ref cbxLanguage);
            SetCbx<Gender>(ref cbxGender);

            cbxResolution.Items.Clear();
            foreach (Resolution item in Enum.GetValues(typeof(Resolution))) {
                cbxResolution.Items.Add(ResolutionReder.ResolutionToString(item));
            };
            cbxResolution.SelectedIndex = 0;

            GetTeams();
            cbxRepres.Items.Clear();
            teams.ForEach(team => cbxRepres.Items.Add(team.ToDisplay()));
            cbxRepres.SelectedIndex = 0;
        }

        private async void GetTeams() {
            try {
                teams = await Repo.Instance.FetchTeams(appSettingsData.gender, appSettingsData.source);
                teams.Sort((x, y) => x.FifaCode.CompareTo(y.FifaCode));
            }
            catch (Exception e) {
                MessageBox.Show("An error acured while fetching data\n" + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Close();
            }
        }

        private void SetCbx<T>(ref ComboBox cbx) {
            cbx.Items.Clear();
            foreach (var item in Enum.GetValues(typeof(T))) {
                cbx.Items.Add(item);
            };
            cbx.SelectedIndex = 0;
        }

        private T ParseToEnum<T>(int n) {
            if (n <= Enum.GetValues(typeof(T)).Length) {
                var e = (T)Enum.Parse(typeof(T), n.ToString());
                return e;
            }
            throw new ArgumentOutOfRangeException();
        }

        private void SettingsWindows_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Escape) CancelStep();
            if (e.Key == Key.Enter) ConfirmStep();
        }

        private void ConfirmStep() {
            if (stage >= 2) {
                Repo.Instance.SaveAppSettings(appSettingsData);
                Repo.Instance.SaveUserSettings(userSettingsData.champoinship, true);
                DialogResult = true;
                Close();
            }
            else {
                spRepres.Visibility = Visibility.Visible;
                spSettings.Visibility = Visibility.Hidden;
                btnConfirm.Content = "Confirm";
                btnCancel.Content = "Back";
            }
            stage++;
        }

        private void CancelStep() {
            if (stage <= 1) {
                DialogResult = false;
                Close();
            }
            else {
                spRepres.Visibility = Visibility.Hidden;
                spSettings.Visibility = Visibility.Visible;
                btnConfirm.Content = "Next";
                btnCancel.Content = "Cancel";
            }
            stage--;
        }
    }
}
