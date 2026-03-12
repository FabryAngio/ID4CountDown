using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Id4Countdown
{
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _timer;
        private DateTime _endTime;

       public MainWindow(TimeSpan duration)
{
    InitializeComponent();

    Loaded += (s, e) => StartCountdown(duration);

    _timer = new DispatcherTimer
    {
        Interval = TimeSpan.FromMilliseconds(10)
    };
    _timer.Tick += Timer_Tick;
}


        private void StartCountdown(TimeSpan duration)
        {
            _endTime = DateTime.Now + duration;
            _timer.Start();
        }

       private void Timer_Tick(object? sender, EventArgs e)
{
    var remaining = _endTime - DateTime.Now;

    if (remaining <= TimeSpan.Zero)
    {
        _timer.Stop();

        HoursBlock.Text = "00";
        MinutesBlock.Text = "00";
        SecondsBlock.Text = "00";
        CentiBlock.Text = ":00";

        return;
    }

    int hours = remaining.Hours + remaining.Days * 24;
    int minutes = remaining.Minutes;
    int seconds = remaining.Seconds;
    int centiseconds = remaining.Milliseconds / 10;

    HoursBlock.Text = $"{hours:00}";
    MinutesBlock.Text = $"{minutes:00}";
    SecondsBlock.Text = $"{seconds:00}";
    CentiBlock.Text = $":{centiseconds:00}";
}


    }
}
