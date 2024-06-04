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
            menuStrip1 = new MenuStrip();
            asdToolStripMenuItem = new ToolStripMenuItem();
            dsdgfsdfsdToolStripMenuItem = new ToolStripMenuItem();
            asdfasdfToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { asdToolStripMenuItem, dsdgfsdfsdToolStripMenuItem, asdfasdfToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // asdToolStripMenuItem
            // 
            asdToolStripMenuItem.Name = "asdToolStripMenuItem";
            asdToolStripMenuItem.Size = new Size(145, 24);
            asdToolStripMenuItem.Text = "Teams and players";
            // 
            // dsdgfsdfsdToolStripMenuItem
            // 
            dsdgfsdfsdToolStripMenuItem.Name = "dsdgfsdfsdToolStripMenuItem";
            dsdgfsdfsdToolStripMenuItem.Size = new Size(78, 24);
            dsdgfsdfsdToolStripMenuItem.Text = "Rank list";
            // 
            // asdfasdfToolStripMenuItem
            // 
            asdfasdfToolStripMenuItem.Name = "asdfasdfToolStripMenuItem";
            asdfasdfToolStripMenuItem.Size = new Size(76, 24);
            asdfasdfToolStripMenuItem.Text = "Settings";
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Main";
            Text = "Form1";
            Load += Main_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem asdToolStripMenuItem;
        private ToolStripMenuItem dsdgfsdfsdToolStripMenuItem;
        private ToolStripMenuItem asdfasdfToolStripMenuItem;
    }
}
