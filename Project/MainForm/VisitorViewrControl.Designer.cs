namespace MainForm {
    partial class VisitorViewrControl {
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
            tableLayoutPanel1 = new TableLayoutPanel();
            lblLocation = new Label();
            lblVisitors = new Label();
            lblHome = new Label();
            lblAway = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(lblAway, 1, 1);
            tableLayoutPanel1.Controls.Add(lblHome, 0, 1);
            tableLayoutPanel1.Controls.Add(lblVisitors, 1, 0);
            tableLayoutPanel1.Controls.Add(lblLocation, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(356, 110);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Dock = DockStyle.Fill;
            lblLocation.Location = new Point(4, 1);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(170, 53);
            lblLocation.TabIndex = 0;
            lblLocation.Text = "label1";
            lblLocation.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblVisitors
            // 
            lblVisitors.AutoSize = true;
            lblVisitors.Dock = DockStyle.Fill;
            lblVisitors.Location = new Point(181, 1);
            lblVisitors.Name = "lblVisitors";
            lblVisitors.Size = new Size(171, 53);
            lblVisitors.TabIndex = 1;
            lblVisitors.Text = "label2";
            lblVisitors.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblHome
            // 
            lblHome.AutoSize = true;
            lblHome.Dock = DockStyle.Fill;
            lblHome.Location = new Point(4, 55);
            lblHome.Name = "lblHome";
            lblHome.Size = new Size(170, 54);
            lblHome.TabIndex = 2;
            lblHome.Text = "label3";
            lblHome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAway
            // 
            lblAway.AutoSize = true;
            lblAway.Dock = DockStyle.Fill;
            lblAway.Location = new Point(181, 55);
            lblAway.Name = "lblAway";
            lblAway.Size = new Size(171, 54);
            lblAway.TabIndex = 3;
            lblAway.Text = "label4";
            lblAway.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // VisitorViewrControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "VisitorViewrControl";
            Size = new Size(356, 110);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label lblAway;
        private Label lblHome;
        private Label lblVisitors;
        private Label lblLocation;
    }
}
