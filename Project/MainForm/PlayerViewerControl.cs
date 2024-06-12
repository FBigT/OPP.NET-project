using FifaLib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainForm {
    public partial class PlayerViewerControl : UserControl {
        public PlayerViewerControl() {
            InitializeComponent();
        }

        public void FillView(Player player) {
            txtbName.Text = player.Name;
            txtbPosition.Text = player.Position;
            txtbNumber.Text = player.ShirtNumber.ToString();
            chbIsCaptain.Checked = player.IsCaptain;

            pictureBox1.Visible = player.IsFavourite;
        }

        public void SetPicture(string path) {
            pbMain.Image = Image.FromFile(path);
        }

        public void SetPicture(Image image) {
            pbMain.Image = image;
        }

        public Image GetImage() {
            return pbMain.Image;
        }

        public string LoadPictureFromFile() {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (ofd.ShowDialog() == DialogResult.OK) {
                string filePath = ofd.FileName;
                if (!File.Exists(filePath)) return string.Empty;
                return filePath;
            }
            return string.Empty;
        }
    }
}
