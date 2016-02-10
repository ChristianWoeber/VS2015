using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartsCore
{
    public class BarChart : IChart
    {
        private float[] _data;
        public BarChart(float[] data )
        {
            _data = data;
        }
        public IChartElement[] GetElements()
        {
            int i = 0;
            List<IChartElement> elements = new List<IChartElement>();
            foreach (var element in _data)
            {
                elements.Add(new Rectangle((int)element, 10, i, 0));
                i += 20;
            }
            return elements.ToArray();
        }

    }
}
