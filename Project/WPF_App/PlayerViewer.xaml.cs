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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_App {
    /// <summary>
    /// Interaction logic for PlayerViewer.xaml
    /// </summary>
    public partial class PlayerViewer : UserControl {
        public PlayerViewer() {
            InitializeComponent();
        }

        public void SetData(Player p) {
            lblName.Content = p.Name;
            lblNumber.Content = p.ShirtNumber;
        }

        public void setMargine(Thickness thickness) {
            Margin = thickness;
        }

        public void SetZ(int z) {
            Panel.SetZIndex(this, z);
        }

        public void SetImage(string imagePath) {
            if (imagePath != string.Empty) {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(imagePath, UriKind.Absolute);
                bitmap.EndInit();

                imgMain.Source = bitmap;
            }
            else {
                imgMain.Source = null;
            }
        }
    }
}
