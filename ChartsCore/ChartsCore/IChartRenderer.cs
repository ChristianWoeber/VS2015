using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartsCore
{
    public interface IChartRenderer
    {
        void Draw(IChart chart);
    }
}
