using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ChartsCore;

namespace ChartRendererWpf
{
    public class WpfChartRenderer : IChartRenderer
    {
        private Canvas _canvas;
        public WpfChartRenderer(Canvas canvas)
        {
            _canvas = canvas;
        }
        public void Draw(IChart chart)
        {
            chart.GetElements();
        }
    }
}
