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
        }

        public void SetData(string player, int goals, int ycards) {
            lblPlayer.Text = player;
            lblData.Text = $"Goals: {goals} | Yellow cards: {ycards}";
        }
    }
}
