namespace MainForm {
    partial class Settings {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            btnConfirm = new Button();
            btnCancel = new Button();
            cbxLanguage = new ComboBox();
            rbMale = new RadioButton();
            rbFemale = new RadioButton();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(12, 158);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(149, 40);
            btnConfirm.TabIndex = 0;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(209, 158);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(149, 40);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // cbxLanguage
            // 
            cbxLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxLanguage.FormattingEnabled = true;
            cbxLanguage.Location = new Point(176, 77);
            cbxLanguage.Name = "cbxLanguage";
            cbxLanguage.Size = new Size(182, 28);
            cbxLanguage.TabIndex = 2;
            cbxLanguage.SelectedIndexChanged += cbxLanguage_SelectedIndexChanged;
            // 
            // rbMale
            // 
            rbMale.AutoSize = true;
            rbMale.Checked = true;
            rbMale.Location = new Point(176, 12);
            rbMale.Name = "rbMale";
            rbMale.Size = new Size(63, 24);
            rbMale.TabIndex = 3;
            rbMale.TabStop = true;
            rbMale.Text = "Male";
            rbMale.UseVisualStyleBackColor = true;
            rbMale.CheckedChanged += rbMale_CheckedChanged;
            // 
            // rbFemale
            // 
            rbFemale.AutoSize = true;
            rbFemale.Location = new Point(176, 42);
            rbFemale.Name = "rbFemale";
            rbFemale.Size = new Size(78, 24);
            rbFemale.TabIndex = 4;
            rbFemale.Text = "Female";
            rbFemale.UseVisualStyleBackColor = true;
            rbFemale.CheckedChanged += rbFemale_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(117, 20);
            label1.TabIndex = 5;
            label1.Text = "Choosen gender";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 77);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 6;
            label2.Text = "Language";
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(370, 210);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(rbFemale);
            Controls.Add(rbMale);
            Controls.Add(cbxLanguage);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "Settings";
            Text = "Settings";
            Load += Settings_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConfirm;
        private Button btnCancel;
        private ComboBox cbxLanguage;
        private RadioButton rbMale;
        private RadioButton rbFemale;
        private Label label1;
        private Label label2;
    }
}