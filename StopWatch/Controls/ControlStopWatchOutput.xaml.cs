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
    /// Interaktionslogik für ControlStopWatchOutput.xaml
    /// </summary>
    public partial class ControlStopWatchOutput
    {
        public ControlStopWatchOutput()
        {
            InitializeComponent();
            txtMM.Text = "00";
            txtSS.Text = "00";
            txtMS.Text = "00";
        }
    }
}
