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
    /// Interaction logic for PlayerWindow.xaml
    /// </summary>
    public partial class PlayerWindow : Window {
        public PlayerWindow() {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        public void SetImage(string path) {
            if (path != string.Empty) {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(path, UriKind.Absolute);
                bitmap.EndInit();

                imgMain.Source = bitmap;
            }
            else {
                imgMain.Source = null;
            }
        }

        public void SetPlayer(Player p, int goals, int yellow) {
            lblName.Content = p.Name;
            lblNumber.Content += p.ShirtNumber.ToString();
            lblPosition.Content += p.Position;
            lblGoals.Content += goals.ToString();
            lblYellow.Content += yellow.ToString();

            cbxCaptain.IsChecked = p.IsCaptain;
        }
    }
}
