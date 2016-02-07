using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Threading;

namespace StopWatch
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void checkTimer_Click(object sender, RoutedEventArgs e)
        {
            if (checkTimer.IsChecked == true)
            {
                cntrlTimer.Visibility = Visibility.Visible;
                cntrlStopWatch.Visibility = Visibility.Collapsed;
            }
            if (checkTimer.IsChecked == false)
            {
                cntrlTimer.Visibility = Visibility.Collapsed;
                cntrlStopWatch.Visibility = Visibility.Visible;
            }
        }
        //private StopWatchCore.Models.StopWatch _watch = new StopWatchCore.Models.StopWatch();
        //private DispatcherTimer _timer = new DispatcherTimer();
        //private ObservableCollection<StopWatchCore.Models.StopWatchItems> LstRoundTimes = new ObservableCollection<StopWatchCore.Models.StopWatchItems>();

        //public MainWindow()
        //{
        //    InitializeComponent();
        //    _timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
        //    _timer.Start();
        //    _timer.Tick += UpdateWatch;
        //   // lstView.ItemsSource = LstRoundTimes;
        //}

        //private void UpdateWatch(object sender, EventArgs e)
        //{
        //    lblAusgabe.Content = _watch.GetCurrentTime();
        //}

        //private void bttnStart_Click(object sender, RoutedEventArgs e)
        //{
        //    _watch.Start();
        //}

        //private void bttnStop_Click(object sender, RoutedEventArgs e)
        //{
        //    _watch.Stop();
        //    if (_watch.Stop() != null && _watch.Stop().TimeStamp > DateTime.MinValue)
        //        LstRoundTimes.Add(_watch.Stop());
        //}

        //private void bttnPause_Click(object sender, RoutedEventArgs e)
        //{
        //    _watch.Pause();
        //}
    }
}
