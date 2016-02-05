using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using StopWatch.ViewModels;

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
            _timer.Start();
            _timer.Tick += UpdateWatchTimer;
        }

        private void UpdateWatchTimer(object sender, EventArgs e)
        {
            lblAusgabeTimer.Content = _viewModel.CurrentTimeTimer;
        }

        private void bttnStart_Click(object sender, RoutedEventArgs e)
        {
            var input = TimeSpan.FromSeconds(Convert.ToDouble(txtInput.Text));
            _viewModel.Start(input);

        }
        //if (bttnStart.IsChecked == false)
        //{
        //    if (_viewModel._watch.Stop() != null && _viewModel._watch.Stop().TimeStamp > DateTime.MinValue)
        //        LstRoundTimes.Add(_viewModel._watch.Stop());

        //}
    }
}

