using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Input;
using System.Windows.Controls.Primitives;

namespace StopWatch
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
           
        }
        private void checkTimer_Click(object sender, RoutedEventArgs e)
        {
            if (checkTimer.IsChecked == true)
            {
                cntrlTimer.Visibility = Visibility.Visible;
                cntrlStopWatch.Visibility = Visibility.Collapsed;
                cntrlStopWatch.IsEnabled = false;
                cntrlTimer.IsEnabled = true;
            }
            if (checkTimer.IsChecked == false)
            {
                cntrlTimer.Visibility = Visibility.Collapsed;
                cntrlStopWatch.Visibility = Visibility.Visible;
                cntrlTimer.IsEnabled = false;
                cntrlStopWatch.IsEnabled = true;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (cntrlStopWatch.IsEnabled == true)
            {
                if (e.Key == Key.Return || e.Key == Key.Enter)
                    cntrlStopWatch.bttnStart_Click(sender, e);

                if (e.Key == Key.F1)
                    MessageBox.Show("you pressed " + e.Key);
            }
           else if (checkTimer.IsEnabled == true)
            {
                if (e.Key == Key.Return || e.Key == Key.Enter)
                    cntrlTimer.bttnStart_Click(sender, e);

                if (e.Key == Key.F1)
                    MessageBox.Show("you pressed " + e.Key);
            }

        }

        private void HorizontalToggleSwitch_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
