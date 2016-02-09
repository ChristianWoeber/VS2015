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
using StopWatchCore.Models;

namespace StopWatch.Controls
{
    /// <summary>
    /// Interaktionslogik für ControlStopWatch.xaml
    /// </summary>
    public partial class ControlStopWatch
    {
        private DispatcherTimer _timer;
        private StopWatchViewModel _viewModel;

        // private ObservableCollection<StopWatchCore.Models.StopWatchItems> LstRoundTimes = new ObservableCollection<StopWatchCore.Models.StopWatchItems>();

        public ControlStopWatch()
        {
            InitializeComponent();
            _timer = new DispatcherTimer();
            _viewModel = new StopWatchViewModel();
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 16);
            lblAusgabe.Content = "00:00:00";
            _timer.Tick += UpdateWatch;
            DataContext = _viewModel;
            //lstView.ItemsSource = _viewModel.LstRoundTimes; 

        }

        private void UpdateWatch(object sender, EventArgs e)
        {
            lblAusgabe.Content = _viewModel.CurrentTime.ToString(@"mm\:ss\:ff");
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

            if (bttnStart.IsChecked == true)
            {
                _viewModel.Start();
                _timer.Start();
            }
            if (bttnStart.IsChecked == false)
            {
                _timer.Stop();
                _viewModel.Pause();

            }
        }

        private void bttnPause_Click(object sender, RoutedEventArgs e)
        {
            lblAusgabe.Content = "00:00:00";
            _viewModel.Stop();
            _timer.Stop();
            bttnStart.IsChecked = false;
        }

        private void bttnShow_Click(object sender, RoutedEventArgs e)
        {
            if (bttnShow.IsChecked == true)
            {
                panelRoundTimes.Visibility = Visibility.Visible;
            }
            else
                panelRoundTimes.Visibility = Visibility.Collapsed;
        }
      
    }
}
