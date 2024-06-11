using FifaLib.Models;

namespace MainForm {
    partial class PlayerViewerControl {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerViewerControl));
            pbMain = new PictureBox();
            label1 = new Label();
            txtbName = new TextBox();
            chbIsCaptain = new CheckBox();
            groupBox1 = new GroupBox();
            pictureBox1 = new PictureBox();
            label6 = new Label();
            txtbPosition = new TextBox();
            label4 = new Label();
            txtbNumber = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pbMain).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pbMain
            // 
            pbMain.BorderStyle = BorderStyle.FixedSingle;
            pbMain.Image = (Image)resources.GetObject("pbMain.Image");
            pbMain.Location = new Point(234, 18);
            pbMain.Name = "pbMain";
            pbMain.Size = new Size(250, 300);
            pbMain.SizeMode = PictureBoxSizeMode.StretchImage;
            pbMain.TabIndex = 0;
            pbMain.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 43);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 1;
            label1.Text = "Name";
            // 
            // txtbName
            // 
            txtbName.Enabled = false;
            txtbName.Location = new Point(6, 66);
            txtbName.Name = "txtbName";
            txtbName.Size = new Size(222, 27);
            txtbName.TabIndex = 2;
            // 
            // chbIsCaptain
            // 
            chbIsCaptain.AutoSize = true;
            chbIsCaptain.Enabled = false;
            chbIsCaptain.Location = new Point(6, 265);
            chbIsCaptain.Name = "chbIsCaptain";
            chbIsCaptain.Size = new Size(94, 24);
            chbIsCaptain.TabIndex = 3;
            chbIsCaptain.Text = "Is captain";
            chbIsCaptain.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(txtbPosition);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(txtbNumber);
            groupBox1.Controls.Add(pbMain);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtbName);
            groupBox1.Controls.Add(chbIsCaptain);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(494, 324);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Current Player";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(384, 218);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            pictureBox1.Visible = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 189);
            label6.Name = "label6";
            label6.Size = new Size(61, 20);
            label6.TabIndex = 8;
            label6.Text = "Position";
            // 
            // txtbPosition
            // 
            txtbPosition.Enabled = false;
            txtbPosition.Location = new Point(6, 212);
            txtbPosition.Name = "txtbPosition";
            txtbPosition.Size = new Size(222, 27);
            txtbPosition.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 116);
            label4.Name = "label4";
            label4.Size = new Size(94, 20);
            label4.TabIndex = 5;
            label4.Text = "Shirt number";
            // 
            // txtbNumber
            // 
            txtbNumber.Enabled = false;
            txtbNumber.Location = new Point(6, 139);
            txtbNumber.Name = "txtbNumber";
            txtbNumber.Size = new Size(222, 27);
            txtbNumber.TabIndex = 6;
            // 
            // PlayerViewerControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox1);
            Name = "PlayerViewerControl";
            Size = new Size(494, 324);
            ((System.ComponentModel.ISupportInitialize)pbMain).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbMain;
        private Label label1;
        private TextBox txtbName;
        private CheckBox chbIsCaptain;
        private GroupBox groupBox1;
        private Label label6;
        private TextBox txtbPosition;
        private Label label4;
        private TextBox txtbNumber;
        private PictureBox pictureBox1;
    }
}
