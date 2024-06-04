namespace MainForm {
    public partial class Main : Form {
        public Main() {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e) {
            if (!File.Exists("appSettings.txt")) {
                Settings settingsForm = new Settings();
                settingsForm.ShowDialog();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e) {

        }
    }
}
