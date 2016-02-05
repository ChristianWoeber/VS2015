using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaktionslogik für ControlStopWatch.xaml
    /// </summary>
    public partial class ControlStopWatch
    {
        private DispatcherTimer _timer;
        private StopWatchViewModel _viewModel;
        private ObservableCollection<StopWatchCore.Models.StopWatchItems> LstRoundTimes = new ObservableCollection<StopWatchCore.Models.StopWatchItems>();

        public ControlStopWatch()
        {
            InitializeComponent();
            _timer = new DispatcherTimer();
            _viewModel = new StopWatchViewModel();
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 16);

            _timer.Tick += UpdateWatch;
            lstView.ItemsSource = LstRoundTimes;


        }

        private void UpdateWatch(object sender, EventArgs e)
        {
            lblAusgabe.Content = _viewModel.CurrentTime;
        }

        private void bttnStart_Click(object sender, RoutedEventArgs e)
        {
            if (bttnStart.IsChecked == null)
                _viewModel._watch.Pause();
            if (bttnStart.IsChecked == true)
            {
                _viewModel._watch.Start();
                _timer.Start();
            }
            if (bttnStart.IsChecked == false)
            {
                _timer.Stop();
                if (_viewModel._watch.Stop() != null && _viewModel._watch.Stop().TimeStamp > DateTime.MinValue)
                    LstRoundTimes.Add(_viewModel._watch.Stop());

            }

        }

        private void bttnPause_Click(object sender, RoutedEventArgs e)
        {
            _viewModel._watch.Pause();
        }

        private void bttnStop_Click(object sender, RoutedEventArgs e)
        {
            _viewModel._watch.Stop();
            if (_viewModel._watch.Stop() != null && _viewModel._watch.Stop().TimeStamp > DateTime.MinValue)
                LstRoundTimes.Add(_viewModel._watch.Stop());
        }
    }
}
