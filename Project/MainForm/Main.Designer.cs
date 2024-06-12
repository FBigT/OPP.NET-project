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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            btnAddImage = new Button();
            cbxRepresentation = new ComboBox();
            lbxOthers = new ListBox();
            playerViewerControl1 = new PlayerViewerControl();
            label3 = new Label();
            label2 = new Label();
            menuStrip = new MenuStrip();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            playerBindingSource = new BindingSource(components);
            lbxFavourites = new ListBox();
            gbRepresentation = new GroupBox();
            lbxAllPlayers = new ListBox();
            flpEvents = new FlowLayoutPanel();
            gbFavourites = new GroupBox();
            btnPrint = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblVisitors = new Label();
            lblPlayerRankings = new Label();
            flpVisitors = new FlowLayoutPanel();
            gbRankigs = new GroupBox();
            ttAllPlayers = new ToolTip(components);
            printDocument1 = new System.Drawing.Printing.PrintDocument();
            printPreviewDialog1 = new PrintPreviewDialog();
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)playerBindingSource).BeginInit();
            gbRepresentation.SuspendLayout();
            gbFavourites.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            gbRankigs.SuspendLayout();
            SuspendLayout();
            // 
            // btnAddImage
            // 
            btnAddImage.Location = new Point(505, 247);
            btnAddImage.Name = "btnAddImage";
            btnAddImage.Size = new Size(163, 52);
            btnAddImage.TabIndex = 12;
            btnAddImage.Text = "Add image";
            btnAddImage.UseVisualStyleBackColor = true;
            btnAddImage.Click += btnAddImage_Click;
            // 
            // cbxRepresentation
            // 
            cbxRepresentation.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cbxRepresentation.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxRepresentation.FormattingEnabled = true;
            cbxRepresentation.Location = new Point(5, 20);
            cbxRepresentation.Name = "cbxRepresentation";
            cbxRepresentation.Size = new Size(323, 28);
            cbxRepresentation.Sorted = true;
            cbxRepresentation.TabIndex = 5;
            cbxRepresentation.SelectedIndexChanged += cbxRepresentation_SelectedIndexChanged;
            // 
            // lbxOthers
            // 
            lbxOthers.AllowDrop = true;
            lbxOthers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lbxOthers.FormattingEnabled = true;
            lbxOthers.ItemHeight = 20;
            lbxOthers.Location = new Point(353, 414);
            lbxOthers.Name = "lbxOthers";
            lbxOthers.Size = new Size(315, 584);
            lbxOthers.Sorted = true;
            lbxOthers.TabIndex = 11;
            lbxOthers.Click += lbxOthers_Click;
            lbxOthers.DragDrop += lbxOthers_DragDrop;
            lbxOthers.DragEnter += lbxOthers_DragEnter;
            lbxOthers.MouseDown += lbxOthers_MouseDown;
            // 
            // playerViewerControl1
            // 
            playerViewerControl1.Location = new Point(6, 26);
            playerViewerControl1.Name = "playerViewerControl1";
            playerViewerControl1.Size = new Size(494, 331);
            playerViewerControl1.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(353, 391);
            label3.Name = "label3";
            label3.Size = new Size(52, 20);
            label3.TabIndex = 9;
            label3.Text = "Others";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 391);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 8;
            label2.Text = "Favourites";
            // 
            // menuStrip
            // 
            menuStrip.GripStyle = ToolStripGripStyle.Visible;
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1848, 28);
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
            // playerBindingSource
            // 
            playerBindingSource.DataSource = typeof(FifaLib.Models.Player);
            // 
            // lbxFavourites
            // 
            lbxFavourites.AllowDrop = true;
            lbxFavourites.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lbxFavourites.FormattingEnabled = true;
            lbxFavourites.ItemHeight = 20;
            lbxFavourites.Location = new Point(6, 414);
            lbxFavourites.Name = "lbxFavourites";
            lbxFavourites.Size = new Size(315, 584);
            lbxFavourites.Sorted = true;
            lbxFavourites.TabIndex = 0;
            lbxFavourites.Click += lbxFavourites_Click;
            lbxFavourites.DragDrop += lbxFavourites_DragDrop;
            lbxFavourites.DragEnter += lbxFavourites_DragEnter;
            lbxFavourites.MouseDown += lbxFavourites_MouseDown;
            // 
            // gbRepresentation
            // 
            gbRepresentation.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            gbRepresentation.Controls.Add(lbxAllPlayers);
            gbRepresentation.Controls.Add(cbxRepresentation);
            gbRepresentation.Location = new Point(12, 31);
            gbRepresentation.Name = "gbRepresentation";
            gbRepresentation.Size = new Size(334, 1009);
            gbRepresentation.TabIndex = 13;
            gbRepresentation.TabStop = false;
            gbRepresentation.Text = "Favourite Representation";
            // 
            // lbxAllPlayers
            // 
            lbxAllPlayers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lbxAllPlayers.FormattingEnabled = true;
            lbxAllPlayers.ItemHeight = 20;
            lbxAllPlayers.Location = new Point(5, 54);
            lbxAllPlayers.Name = "lbxAllPlayers";
            lbxAllPlayers.Size = new Size(323, 944);
            lbxAllPlayers.Sorted = true;
            lbxAllPlayers.TabIndex = 8;
            ttAllPlayers.SetToolTip(lbxAllPlayers, "To move players to favourites double click the desired player.");
            lbxAllPlayers.DoubleClick += lbxAllPlayers_DoubleClick;
            // 
            // flpEvents
            // 
            flpEvents.AutoScroll = true;
            flpEvents.Dock = DockStyle.Fill;
            flpEvents.Location = new Point(5, 27);
            flpEvents.Name = "flpEvents";
            flpEvents.Size = new Size(390, 951);
            flpEvents.TabIndex = 16;
            flpEvents.Click += flpEvents_Click;
            // 
            // gbFavourites
            // 
            gbFavourites.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbFavourites.Controls.Add(btnPrint);
            gbFavourites.Controls.Add(btnAddImage);
            gbFavourites.Controls.Add(lbxOthers);
            gbFavourites.Controls.Add(playerViewerControl1);
            gbFavourites.Controls.Add(lbxFavourites);
            gbFavourites.Controls.Add(label3);
            gbFavourites.Controls.Add(label2);
            gbFavourites.Location = new Point(352, 31);
            gbFavourites.Name = "gbFavourites";
            gbFavourites.Size = new Size(674, 1009);
            gbFavourites.TabIndex = 17;
            gbFavourites.TabStop = false;
            gbFavourites.Text = "Favourite Players";
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(505, 305);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(163, 52);
            btnPrint.TabIndex = 13;
            btnPrint.Text = "Print file";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(lblVisitors, 1, 0);
            tableLayoutPanel1.Controls.Add(flpEvents, 0, 1);
            tableLayoutPanel1.Controls.Add(lblPlayerRankings, 0, 0);
            tableLayoutPanel1.Controls.Add(flpVisitors, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 23);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(798, 983);
            tableLayoutPanel1.TabIndex = 18;
            // 
            // lblVisitors
            // 
            lblVisitors.AutoSize = true;
            lblVisitors.Dock = DockStyle.Fill;
            lblVisitors.Location = new Point(403, 2);
            lblVisitors.MaximumSize = new Size(0, 26);
            lblVisitors.Name = "lblVisitors";
            lblVisitors.Size = new Size(390, 20);
            lblVisitors.TabIndex = 13;
            lblVisitors.Text = "Visitors";
            lblVisitors.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPlayerRankings
            // 
            lblPlayerRankings.AutoSize = true;
            lblPlayerRankings.Dock = DockStyle.Fill;
            lblPlayerRankings.Location = new Point(5, 2);
            lblPlayerRankings.MaximumSize = new Size(0, 26);
            lblPlayerRankings.Name = "lblPlayerRankings";
            lblPlayerRankings.Size = new Size(390, 20);
            lblPlayerRankings.TabIndex = 0;
            lblPlayerRankings.Text = "Player Rankings";
            lblPlayerRankings.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flpVisitors
            // 
            flpVisitors.AutoScroll = true;
            flpVisitors.Dock = DockStyle.Fill;
            flpVisitors.Location = new Point(403, 27);
            flpVisitors.Name = "flpVisitors";
            flpVisitors.Size = new Size(390, 951);
            flpVisitors.TabIndex = 17;
            // 
            // gbRankigs
            // 
            gbRankigs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            gbRankigs.Controls.Add(tableLayoutPanel1);
            gbRankigs.Location = new Point(1032, 31);
            gbRankigs.Name = "gbRankigs";
            gbRankigs.Size = new Size(804, 1009);
            gbRankigs.TabIndex = 19;
            gbRankigs.TabStop = false;
            gbRankigs.Text = "Rankings";
            // 
            // ttAllPlayers
            // 
            ttAllPlayers.ToolTipIcon = ToolTipIcon.Info;
            ttAllPlayers.ToolTipTitle = "Player Managment";
            // 
            // printDocument1
            // 
            printDocument1.PrintPage += printDocument1_PrintPage;
            // 
            // printPreviewDialog1
            // 
            printPreviewDialog1.AutoScrollMargin = new Size(0, 0);
            printPreviewDialog1.AutoScrollMinSize = new Size(0, 0);
            printPreviewDialog1.ClientSize = new Size(400, 300);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Enabled = true;
            printPreviewDialog1.Icon = (Icon)resources.GetObject("printPreviewDialog1.Icon");
            printPreviewDialog1.Name = "printPreviewDialog1";
            printPreviewDialog1.Visible = false;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1848, 1052);
            Controls.Add(gbRankigs);
            Controls.Add(gbFavourites);
            Controls.Add(gbRepresentation);
            Controls.Add(menuStrip);
            MinimumSize = new Size(1866, 938);
            Name = "Main";
            Text = "Fifa Championship";
            FormClosing += Main_FormClosing;
            Load += Main_Load;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)playerBindingSource).EndInit();
            gbRepresentation.ResumeLayout(false);
            gbFavourites.ResumeLayout(false);
            gbFavourites.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            gbRankigs.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label3;
        private Label label2;
        private PlayerViewerControl playerViewerControl1;
        private MenuStrip menuStrip;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ListBox lbxOthers;
        private BindingSource playerBindingSource;
        private Button btnAddImage;
        private Button btnSelect;
        private CheckedListBox cblPlayers;
        private ComboBox cbxRepresentation;
        private ListBox lbxFavourites;
        private GroupBox gbRepresentation;
        private FlowLayoutPanel flpEvents;
        private GroupBox gbFavourites;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblVisitors;
        private GroupBox gbRankigs;
        private Label lblPlayerRankings;
        private ListBox lbxAllPlayers;
        private ToolTip ttAllPlayers;
        private FlowLayoutPanel flpVisitors;
        private Button btnPrint;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private PrintPreviewDialog printPreviewDialog1;
    }
}
