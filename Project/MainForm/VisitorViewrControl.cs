namespace MainForm {
    public partial class VisitorViewrControl : UserControl {
        public VisitorViewrControl() {
            InitializeComponent();
        }

        public void SetText(string location, string attendance, string home, string away) {
            lblLocation.Text = $"Location: {location}";
            lblVisitors.Text = $"Attendance: {attendance}";
            lblHome.Text = $"Home team - {location}";
            lblAway.Text = $"Away team - {location}";
        }
    }
}
