namespace MainForm {
    partial class PlayerViewerSmallControll {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            pbxMain = new PictureBox();
            tlpMain = new TableLayoutPanel();
            tlpData = new TableLayoutPanel();
            lblData = new Label();
            lblPlayer = new Label();
            ((System.ComponentModel.ISupportInitialize)pbxMain).BeginInit();
            tlpMain.SuspendLayout();
            tlpData.SuspendLayout();
            SuspendLayout();
            // 
            // pbxMain
            // 
            pbxMain.BorderStyle = BorderStyle.FixedSingle;
            pbxMain.Dock = DockStyle.Fill;
            pbxMain.Image = Properties.Resources.no_image_2;
            pbxMain.Location = new Point(252, 3);
            pbxMain.Name = "pbxMain";
            pbxMain.Size = new Size(101, 104);
            pbxMain.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxMain.TabIndex = 0;
            pbxMain.TabStop = false;
            // 
            // tlpMain
            // 
            tlpMain.ColumnCount = 2;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tlpMain.Controls.Add(pbxMain, 1, 0);
            tlpMain.Controls.Add(tlpData, 0, 0);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(0, 0);
            tlpMain.Name = "tlpMain";
            tlpMain.RowCount = 1;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.Size = new Size(356, 110);
            tlpMain.TabIndex = 1;
            // 
            // tlpData
            // 
            tlpData.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tlpData.ColumnCount = 1;
            tlpData.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpData.Controls.Add(lblData, 0, 1);
            tlpData.Controls.Add(lblPlayer, 0, 0);
            tlpData.Dock = DockStyle.Fill;
            tlpData.Location = new Point(3, 3);
            tlpData.Name = "tlpData";
            tlpData.RowCount = 2;
            tlpData.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpData.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpData.Size = new Size(243, 104);
            tlpData.TabIndex = 1;
            // 
            // lblData
            // 
            lblData.AutoSize = true;
            lblData.Dock = DockStyle.Fill;
            lblData.Location = new Point(4, 52);
            lblData.Name = "lblData";
            lblData.Size = new Size(235, 51);
            lblData.TabIndex = 1;
            lblData.Text = "data";
            lblData.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPlayer
            // 
            lblPlayer.AutoSize = true;
            lblPlayer.Dock = DockStyle.Fill;
            lblPlayer.Location = new Point(4, 1);
            lblPlayer.Name = "lblPlayer";
            lblPlayer.Size = new Size(235, 50);
            lblPlayer.TabIndex = 0;
            lblPlayer.Text = "player";
            lblPlayer.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // PlayerViewerSmallControll
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlpMain);
            Name = "PlayerViewerSmallControll";
            Size = new Size(356, 110);
            ((System.ComponentModel.ISupportInitialize)pbxMain).EndInit();
            tlpMain.ResumeLayout(false);
            tlpData.ResumeLayout(false);
            tlpData.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbxMain;
        private TableLayoutPanel tlpMain;
        private TableLayoutPanel tlpData;
        private Label lblPlayer;
        private Label lblData;
    }
}
