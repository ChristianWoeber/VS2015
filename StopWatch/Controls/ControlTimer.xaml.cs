using System;
using System.Windows;
using System.Windows.Threading;
using StopWatch.ViewModels;
using StopWatchCore.Models;

namespace StopWatch.Controls
{
    /// <summary>
    /// Interaktionslogik für ControlTimer.xaml
    /// </summary>
    public partial class ControlTimer
    {
        private DispatcherTimer _timer;
        private StopWatchTimerViewModel _viewModel;

        public ControlTimer()
        {
            InitializeComponent();
            _timer = new DispatcherTimer();
            _viewModel = new StopWatchTimerViewModel();
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 16);
            _viewModel._watch.StopWatchStateChangedToIdle += _watch_StopWatchStateChangedToIdle;
            _timer.Tick += UpdateWatchTimer;
            lblAusgabeTimer.Content = "00:00:00";
        }

        private void _watch_StopWatchStateChangedToIdle(object source, EventArgs args)
        {
            bttnStart.IsChecked = false;
            _viewModel.Stop();
            _timer.Stop();
        }

        private void UpdateWatchTimer(object sender, EventArgs e)
        {
            lblAusgabeTimer.Content = _viewModel.CurrentTimeTimer.ToString(@"mm\:ss\:ff");
            // checkState(sender, e);
        }

        public void bttnStart_Click(object sender, RoutedEventArgs e)
        {
            var ctx = sender as MainWindow;
            if (ctx is MainWindow)
            {
                if (bttnStart.IsChecked == false)
                    bttnStart.IsChecked = true;
                else
                    bttnStart.IsChecked = false;
            }

            var input = txtInput.Text;
            double ret;

            if (double.TryParse(input, out ret))
            {
                var inputTimespan = TimeSpan.FromSeconds(ret);
                if (bttnStart.IsChecked == true)
                {
                    _viewModel.Start(inputTimespan);
                    _timer.Start();

                }
                else if (bttnStart.IsChecked == false)
                    bttnPaused_Click(sender, e);
            }
        }

        private void checkState(object sender, EventArgs e)
        {
            if (_viewModel.State == StopWatchState.Idle)
            {
                bttnStart.IsChecked = false;
                _viewModel.Stop();
                _timer.Stop();
            }
            else
                return;
        }

        private void bttnPaused_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Paused();
            _timer.Stop();
        }

    }
}

