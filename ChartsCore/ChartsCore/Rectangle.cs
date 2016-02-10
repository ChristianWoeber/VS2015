using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartsCore
{
    public class Rectangle : IChartElement
    {
        public Rectangle(int heigt, int widht, int x, int y)
        {
            Height = heigt;
            Width = widht;
            X = x;
            Y = y;
        }
        public int Height { get; set; }
        public int Width { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
