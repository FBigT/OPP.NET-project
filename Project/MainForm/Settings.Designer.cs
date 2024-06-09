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
            rbAPI = new RadioButton();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            rbFile = new RadioButton();
            label2 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(12, 190);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(149, 40);
            btnConfirm.TabIndex = 0;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(170, 190);
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
            cbxLanguage.Location = new Point(92, 144);
            cbxLanguage.Name = "cbxLanguage";
            cbxLanguage.Size = new Size(227, 28);
            cbxLanguage.TabIndex = 2;
            cbxLanguage.SelectedIndexChanged += cbxLanguage_SelectedIndexChanged;
            // 
            // rbMale
            // 
            rbMale.AutoSize = true;
            rbMale.Checked = true;
            rbMale.Location = new Point(11, 26);
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
            rbFemale.Location = new Point(106, 26);
            rbFemale.Name = "rbFemale";
            rbFemale.Size = new Size(78, 24);
            rbFemale.TabIndex = 4;
            rbFemale.Text = "Female";
            rbFemale.UseVisualStyleBackColor = true;
            rbFemale.CheckedChanged += rbFemale_CheckedChanged;
            // 
            // rbAPI
            // 
            rbAPI.AutoSize = true;
            rbAPI.Checked = true;
            rbAPI.Location = new Point(11, 26);
            rbAPI.Name = "rbAPI";
            rbAPI.Size = new Size(52, 24);
            rbAPI.TabIndex = 8;
            rbAPI.TabStop = true;
            rbAPI.Text = "API";
            rbAPI.UseVisualStyleBackColor = true;
            rbAPI.CheckedChanged += rbAPI_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbMale);
            groupBox1.Controls.Add(rbFemale);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(307, 59);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Gender";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rbFile);
            groupBox2.Controls.Add(rbAPI);
            groupBox2.Location = new Point(12, 73);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(307, 59);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Data source";
            // 
            // rbFile
            // 
            rbFile.AutoSize = true;
            rbFile.Location = new Point(106, 26);
            rbFile.Name = "rbFile";
            rbFile.Size = new Size(53, 24);
            rbFile.TabIndex = 9;
            rbFile.Text = "File";
            rbFile.UseVisualStyleBackColor = true;
            rbFile.CheckedChanged += rbFile_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 144);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 6;
            label2.Text = "Language";
            // 
            // Settings
            // 
            AcceptButton = btnConfirm;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(331, 242);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label2);
            Controls.Add(cbxLanguage);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "Settings";
            Text = "Settings";
            Load += Settings_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnConfirm;
        private Button btnCancel;
        private ComboBox cbxLanguage;
        private RadioButton rbMale;
        private RadioButton rbFemale;
        private RadioButton rbAPI;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label2;
        private RadioButton rbFile;
    }
}