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
    public partial class PlayerViewerSmallControll : UserControl {
        public PlayerViewerSmallControll() {
            InitializeComponent();
            this.MouseEnter += (sender, e) => {
                this.BorderStyle = BorderStyle.Fixed3D;
                var a = 1;
            };
            this.MouseLeave += (sender, e) => { 
                this.BorderStyle = BorderStyle.FixedSingle; 
            };

            this.Click += MyCustomControl_Click;
        }

        private void MyCustomControl_Click(object sender, EventArgs e) {
            PlayerViewerSmallControll clickedControl = sender as PlayerViewerSmallControll;

            foreach (PlayerViewerSmallControll control in Parent.Controls) {
                control.BackColor = Color.LightGray;
            }

            clickedControl.BackColor = Color.LightBlue;
        }

        public void SetData(string player, int goals, int ycards) {
            lblPlayer.Text = player;
            lblData.Text = $"Goals: {goals} | Yellow cards: {ycards}";
        }

        public void SetImage(Image image) {
            pbxMain.Image = image;
        }

        public string? GetName() {
            return lblPlayer.Text;
        }
    }
}
