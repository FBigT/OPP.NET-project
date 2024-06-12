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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
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
            resources.ApplyResources(btnConfirm, "btnConfirm");
            btnConfirm.Name = "btnConfirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            resources.ApplyResources(btnCancel, "btnCancel");
            btnCancel.Name = "btnCancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // cbxLanguage
            // 
            cbxLanguage.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxLanguage.FormattingEnabled = true;
            resources.ApplyResources(cbxLanguage, "cbxLanguage");
            cbxLanguage.Name = "cbxLanguage";
            cbxLanguage.SelectedIndexChanged += cbxLanguage_SelectedIndexChanged;
            // 
            // rbMale
            // 
            resources.ApplyResources(rbMale, "rbMale");
            rbMale.Checked = true;
            rbMale.Name = "rbMale";
            rbMale.TabStop = true;
            rbMale.UseVisualStyleBackColor = true;
            rbMale.CheckedChanged += rbMale_CheckedChanged;
            // 
            // rbFemale
            // 
            resources.ApplyResources(rbFemale, "rbFemale");
            rbFemale.Name = "rbFemale";
            rbFemale.UseVisualStyleBackColor = true;
            rbFemale.CheckedChanged += rbFemale_CheckedChanged;
            // 
            // rbAPI
            // 
            resources.ApplyResources(rbAPI, "rbAPI");
            rbAPI.Checked = true;
            rbAPI.Name = "rbAPI";
            rbAPI.TabStop = true;
            rbAPI.UseVisualStyleBackColor = true;
            rbAPI.CheckedChanged += rbAPI_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbMale);
            groupBox1.Controls.Add(rbFemale);
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rbFile);
            groupBox2.Controls.Add(rbAPI);
            resources.ApplyResources(groupBox2, "groupBox2");
            groupBox2.Name = "groupBox2";
            groupBox2.TabStop = false;
            // 
            // rbFile
            // 
            resources.ApplyResources(rbFile, "rbFile");
            rbFile.Name = "rbFile";
            rbFile.UseVisualStyleBackColor = true;
            rbFile.CheckedChanged += rbFile_CheckedChanged;
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // Settings
            // 
            AcceptButton = btnConfirm;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label2);
            Controls.Add(cbxLanguage);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "Settings";
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