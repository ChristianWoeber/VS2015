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
        private ControlTimerOutput _cntrl;

        public ControlTimer()
        {
            InitializeComponent();
            _timer = new DispatcherTimer();
            _viewModel = new StopWatchTimerViewModel();
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 16);
            _viewModel._watch.StopWatchStateChangedToIdle += _watch_StopWatchStateChangedToIdle;
            _timer.Tick += UpdateWatchTimer;         
            _cntrl = cntrlTimerOutput;
        }
   
        private void _watch_StopWatchStateChangedToIdle(object source, EventArgs args)
        {
            bttnStart.IsChecked = false;
            _viewModel.Stop();
            _timer.Stop();
        }

        private void UpdateWatchTimer(object sender, EventArgs e)
        {       
            _cntrl.txtMM.Text = _viewModel.CurrentTimeTimer.Minutes.ToString("00");
            _cntrl.txtSS.Text = _viewModel.CurrentTimeTimer.Seconds.ToString("00");
            _cntrl.txtMS.Text = string.Format("{0:000}", _viewModel.CurrentTimeTimer.Milliseconds);
          
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

           
            var inputTimespan = checkInput(_cntrl.txtMM.Text, _cntrl.txtSS.Text);
                if (bttnStart.IsChecked == true)
                {
                    _viewModel.Start(inputTimespan);
                    _timer.Start();

                }
                else if (bttnStart.IsChecked == false)
                    bttnPaused_Click(sender, e);
            
        }

        private TimeSpan checkInput(string MM, string SS)
        {
            double ret1;
            double ret2;
            if (double.TryParse(MM, out ret1) && double.TryParse(SS, out ret2))            
                return TimeSpan.FromMinutes(ret1) + TimeSpan.FromSeconds(ret2);            
            if (double.TryParse(MM, out ret1))
                return TimeSpan.FromMinutes(ret1);
            if (double.TryParse(SS, out ret2))
                return TimeSpan.FromMinutes(ret2);
            else
                return TimeSpan.Zero;

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

