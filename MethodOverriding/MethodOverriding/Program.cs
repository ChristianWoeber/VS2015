using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodOverriding
{
    class Program
    {
        static void Main(string[] args)
        {

            var lstShapes = new List<Shape>();
            lstShapes.Add(new Circle());
           // lstShapes.Add(new Triangle { Widht = 5, Height = 10 });
            lstShapes.Add(new Rectangle { Widht = 5, Height = 15 });
            var canvas = new Canvas();

            canvas.DrawShape(lstShapes);

        }
    }


}
