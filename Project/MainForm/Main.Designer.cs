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
            btnMargins = new Button();
            btnPreview = new Button();
            btnPrint = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            lblVisitors = new Label();
            lblPlayerRankings = new Label();
            flpVisitors = new FlowLayoutPanel();
            gbRankigs = new GroupBox();
            ttAllPlayers = new ToolTip(components);
            printPreviewDialog = new PrintPreviewDialog();
            printDocument = new System.Drawing.Printing.PrintDocument();
            pageSetupDialog = new PageSetupDialog();
            printDialog = new PrintDialog();
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
            resources.ApplyResources(btnAddImage, "btnAddImage");
            btnAddImage.Name = "btnAddImage";
            btnAddImage.UseVisualStyleBackColor = true;
            btnAddImage.Click += btnAddImage_Click;
            // 
            // cbxRepresentation
            // 
            resources.ApplyResources(cbxRepresentation, "cbxRepresentation");
            cbxRepresentation.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxRepresentation.FormattingEnabled = true;
            cbxRepresentation.Name = "cbxRepresentation";
            cbxRepresentation.Sorted = true;
            cbxRepresentation.SelectedIndexChanged += cbxRepresentation_SelectedIndexChanged;
            // 
            // lbxOthers
            // 
            lbxOthers.AllowDrop = true;
            resources.ApplyResources(lbxOthers, "lbxOthers");
            lbxOthers.FormattingEnabled = true;
            lbxOthers.Name = "lbxOthers";
            lbxOthers.Sorted = true;
            lbxOthers.Click += lbxOthers_Click;
            lbxOthers.DragDrop += lbxOthers_DragDrop;
            lbxOthers.DragEnter += lbxOthers_DragEnter;
            lbxOthers.MouseDown += lbxOthers_MouseDown;
            // 
            // playerViewerControl1
            // 
            resources.ApplyResources(playerViewerControl1, "playerViewerControl1");
            playerViewerControl1.Name = "playerViewerControl1";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // menuStrip
            // 
            menuStrip.GripStyle = ToolStripGripStyle.Visible;
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem });
            resources.ApplyResources(menuStrip, "menuStrip");
            menuStrip.Name = "menuStrip";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            resources.ApplyResources(settingsToolStripMenuItem, "settingsToolStripMenuItem");
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // playerBindingSource
            // 
            playerBindingSource.DataSource = typeof(FifaLib.Models.Player);
            // 
            // lbxFavourites
            // 
            lbxFavourites.AllowDrop = true;
            resources.ApplyResources(lbxFavourites, "lbxFavourites");
            lbxFavourites.FormattingEnabled = true;
            lbxFavourites.Name = "lbxFavourites";
            lbxFavourites.Sorted = true;
            lbxFavourites.Click += lbxFavourites_Click;
            lbxFavourites.DragDrop += lbxFavourites_DragDrop;
            lbxFavourites.DragEnter += lbxFavourites_DragEnter;
            lbxFavourites.MouseDown += lbxFavourites_MouseDown;
            // 
            // gbRepresentation
            // 
            resources.ApplyResources(gbRepresentation, "gbRepresentation");
            gbRepresentation.Controls.Add(lbxAllPlayers);
            gbRepresentation.Controls.Add(cbxRepresentation);
            gbRepresentation.Name = "gbRepresentation";
            gbRepresentation.TabStop = false;
            // 
            // lbxAllPlayers
            // 
            resources.ApplyResources(lbxAllPlayers, "lbxAllPlayers");
            lbxAllPlayers.FormattingEnabled = true;
            lbxAllPlayers.Name = "lbxAllPlayers";
            lbxAllPlayers.Sorted = true;
            ttAllPlayers.SetToolTip(lbxAllPlayers, resources.GetString("lbxAllPlayers.ToolTip"));
            lbxAllPlayers.DoubleClick += lbxAllPlayers_DoubleClick;
            // 
            // flpEvents
            // 
            resources.ApplyResources(flpEvents, "flpEvents");
            flpEvents.Name = "flpEvents";
            // 
            // gbFavourites
            // 
            resources.ApplyResources(gbFavourites, "gbFavourites");
            gbFavourites.Controls.Add(btnMargins);
            gbFavourites.Controls.Add(btnPreview);
            gbFavourites.Controls.Add(btnPrint);
            gbFavourites.Controls.Add(btnAddImage);
            gbFavourites.Controls.Add(lbxOthers);
            gbFavourites.Controls.Add(playerViewerControl1);
            gbFavourites.Controls.Add(lbxFavourites);
            gbFavourites.Controls.Add(label3);
            gbFavourites.Controls.Add(label2);
            gbFavourites.Name = "gbFavourites";
            gbFavourites.TabStop = false;
            // 
            // btnMargins
            // 
            resources.ApplyResources(btnMargins, "btnMargins");
            btnMargins.Name = "btnMargins";
            btnMargins.UseVisualStyleBackColor = true;
            btnMargins.Click += btnMargins_Click;
            // 
            // btnPreview
            // 
            resources.ApplyResources(btnPreview, "btnPreview");
            btnPreview.Name = "btnPreview";
            btnPreview.UseVisualStyleBackColor = true;
            btnPreview.Click += btnPreview_Click;
            // 
            // btnPrint
            // 
            resources.ApplyResources(btnPrint, "btnPrint");
            btnPrint.Name = "btnPrint";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(tableLayoutPanel1, "tableLayoutPanel1");
            tableLayoutPanel1.Controls.Add(lblVisitors, 1, 0);
            tableLayoutPanel1.Controls.Add(flpEvents, 0, 1);
            tableLayoutPanel1.Controls.Add(lblPlayerRankings, 0, 0);
            tableLayoutPanel1.Controls.Add(flpVisitors, 1, 1);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // lblVisitors
            // 
            resources.ApplyResources(lblVisitors, "lblVisitors");
            lblVisitors.Name = "lblVisitors";
            // 
            // lblPlayerRankings
            // 
            resources.ApplyResources(lblPlayerRankings, "lblPlayerRankings");
            lblPlayerRankings.Name = "lblPlayerRankings";
            // 
            // flpVisitors
            // 
            resources.ApplyResources(flpVisitors, "flpVisitors");
            flpVisitors.Name = "flpVisitors";
            // 
            // gbRankigs
            // 
            resources.ApplyResources(gbRankigs, "gbRankigs");
            gbRankigs.Controls.Add(tableLayoutPanel1);
            gbRankigs.Name = "gbRankigs";
            gbRankigs.TabStop = false;
            // 
            // ttAllPlayers
            // 
            ttAllPlayers.ToolTipIcon = ToolTipIcon.Info;
            ttAllPlayers.ToolTipTitle = "Player Managment";
            // 
            // printPreviewDialog
            // 
            resources.ApplyResources(printPreviewDialog, "printPreviewDialog");
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.Name = "printPreviewDialog1";
            // 
            // printDocument
            // 
            printDocument.PrintPage += printDocument_PrintPage;
            // 
            // pageSetupDialog
            // 
            pageSetupDialog.Document = printDocument;
            // 
            // printDialog
            // 
            printDialog.Document = printDocument;
            printDialog.UseEXDialog = true;
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gbRankigs);
            Controls.Add(gbFavourites);
            Controls.Add(gbRepresentation);
            Controls.Add(menuStrip);
            Name = "Main";
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
        private System.Drawing.Printing.PrintDocument printDocument;
        private PrintPreviewDialog printPreviewDialog;
        private PageSetupDialog pageSetupDialog;
        private PrintDialog printDialog;
        private Button btnPreview;
        private Button btnMargins;
    }
}
