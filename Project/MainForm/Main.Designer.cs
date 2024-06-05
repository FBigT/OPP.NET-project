namespace MainForm {
    partial class Main {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            lbxOthers = new ListBox();
            lbxFavourites = new ListBox();
            playerViewerControl1 = new PlayerViewerControl();
            label3 = new Label();
            label2 = new Label();
            chbSort = new CheckBox();
            btnSelect = new Button();
            cblPlayers = new CheckedListBox();
            cbxRepresentation = new ComboBox();
            label1 = new Label();
            tabPage2 = new TabPage();
            menuStrip = new MenuStrip();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(0, 31);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(932, 622);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(lbxOthers);
            tabPage1.Controls.Add(lbxFavourites);
            tabPage1.Controls.Add(playerViewerControl1);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(chbSort);
            tabPage1.Controls.Add(btnSelect);
            tabPage1.Controls.Add(cblPlayers);
            tabPage1.Controls.Add(cbxRepresentation);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(924, 589);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Teams and players";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // lbxOthers
            // 
            lbxOthers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lbxOthers.FormattingEnabled = true;
            lbxOthers.ItemHeight = 20;
            lbxOthers.Location = new Point(672, 44);
            lbxOthers.Name = "lbxOthers";
            lbxOthers.SelectionMode = SelectionMode.MultiExtended;
            lbxOthers.Size = new Size(244, 184);
            lbxOthers.TabIndex = 11;
            // 
            // lbxFavourites
            // 
            lbxFavourites.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            lbxFavourites.FormattingEnabled = true;
            lbxFavourites.ItemHeight = 20;
            lbxFavourites.Location = new Point(422, 44);
            lbxFavourites.Name = "lbxFavourites";
            lbxFavourites.SelectionMode = SelectionMode.MultiExtended;
            lbxFavourites.Size = new Size(244, 184);
            lbxFavourites.TabIndex = 0;
            // 
            // playerViewerControl1
            // 
            playerViewerControl1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            playerViewerControl1.Location = new Point(422, 250);
            playerViewerControl1.Name = "playerViewerControl1";
            playerViewerControl1.Size = new Size(494, 331);
            playerViewerControl1.TabIndex = 10;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(672, 21);
            label3.Name = "label3";
            label3.Size = new Size(52, 20);
            label3.TabIndex = 9;
            label3.Text = "Others";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(422, 21);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 8;
            label2.Text = "Favourites";
            // 
            // chbSort
            // 
            chbSort.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chbSort.AutoSize = true;
            chbSort.Location = new Point(358, 44);
            chbSort.Name = "chbSort";
            chbSort.Size = new Size(58, 24);
            chbSort.TabIndex = 6;
            chbSort.Text = "Sort";
            chbSort.UseVisualStyleBackColor = true;
            // 
            // btnSelect
            // 
            btnSelect.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSelect.Location = new Point(7, 552);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(312, 29);
            btnSelect.TabIndex = 4;
            btnSelect.Text = "Select";
            btnSelect.UseVisualStyleBackColor = true;
            // 
            // cblPlayers
            // 
            cblPlayers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            cblPlayers.CheckOnClick = true;
            cblPlayers.FormattingEnabled = true;
            cblPlayers.Location = new Point(7, 78);
            cblPlayers.Name = "cblPlayers";
            cblPlayers.Size = new Size(310, 444);
            cblPlayers.TabIndex = 3;
            // 
            // cbxRepresentation
            // 
            cbxRepresentation.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxRepresentation.FormattingEnabled = true;
            cbxRepresentation.Location = new Point(6, 44);
            cbxRepresentation.Name = "cbxRepresentation";
            cbxRepresentation.Size = new Size(312, 28);
            cbxRepresentation.TabIndex = 1;
            cbxRepresentation.SelectedIndexChanged += cbxRepresentation_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 21);
            label1.Name = "label1";
            label1.Size = new Size(169, 20);
            label1.TabIndex = 0;
            label1.Text = "Favourite representation";
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(924, 589);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Rankings";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // menuStrip
            // 
            menuStrip.GripStyle = ToolStripGripStyle.Visible;
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(932, 28);
            menuStrip.TabIndex = 2;
            menuStrip.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(76, 24);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(932, 653);
            Controls.Add(tabControl1);
            Controls.Add(menuStrip);
            MinimumSize = new Size(950, 700);
            Name = "Main";
            Text = "Fifa Championship";
            Load += Main_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ComboBox cbxRepresentation;
        private Label label1;
        private Button btnSelect;
        private CheckedListBox cblPlayers;
        private Label label3;
        private Label label2;
        private CheckBox chbSort;
        private PlayerViewerControl playerViewerControl1;
        private MenuStrip menuStrip;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ListBox lbxOthers;
        private ListBox lbxFavourites;
    }
}
