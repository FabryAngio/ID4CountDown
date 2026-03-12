using System;
using System.Windows;

namespace Id4Countdown
{
    public partial class InputWindow : Window
    {
        public TimeSpan SelectedTime { get; private set; }

        public InputWindow()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int h = int.Parse(HoursBox.Text);
                int m = int.Parse(MinutesBox.Text);
                int s = int.Parse(SecondsBox.Text);

                SelectedTime = new TimeSpan(h, m, s);
                DialogResult = true;
                Close();
            }
            catch
            {
                MessageBox.Show("Inserisci valori numerici validi.");
            }
        }
    }
}
