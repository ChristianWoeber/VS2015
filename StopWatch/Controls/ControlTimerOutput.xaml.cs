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

namespace StopWatch.Controls
{
    /// <summary>
    /// Interaktionslogik für ControlTimerOutput.xaml
    /// </summary>
    public partial class ControlTimerOutput
    {
        public ControlTimerOutput()
        {
            InitializeComponent();
            txtMM.Text = "00";
            txtSS.Text = "00";
            txtMS.Text = "00";
        }

        private void bttnUpMM_Click(object sender, RoutedEventArgs e)
        {
            var input = txtMM.Text;
            double ret;

            if (double.TryParse(input, out ret))
            {
                ret += 1;
                txtMM.Text = TimeSpan.FromMinutes(ret).ToString(@"mm");
            }
        }

        private void bttnDownMM_Click(object sender, RoutedEventArgs e)
        {
            var input = txtMM.Text;
            double ret;

            if (double.TryParse(input, out ret))
            {
                if (ret > 0)
                {
                    ret -= 1;
                    txtMM.Text = TimeSpan.FromMinutes(ret).ToString(@"mm");
                }
                ret = 00;
                //txtMM.Text = ret.ToString();
            }
        }

        private void bttnUpSS_Click(object sender, RoutedEventArgs e)
        {
            var input = txtSS.Text;
            double ret;

            if (double.TryParse(input, out ret))
            {
                ret += 10;
                txtSS.Text = TimeSpan.FromSeconds(ret).ToString(@"ss");
            }
        }

        private void bttnDownSS_Click(object sender, RoutedEventArgs e)
        {
            var input = txtSS.Text;
            double ret;

            if (double.TryParse(input, out ret))
            {
                if (ret > 0)
                {
                    ret -= 10;
                    txtSS.Text = TimeSpan.FromSeconds(ret).ToString(@"ss");
                }
                ret = 00;
              
            }
        }
    }
}
