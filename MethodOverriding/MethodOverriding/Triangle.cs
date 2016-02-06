using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodOverriding
{
    public class Triangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Draw a Triangle");

            for (int i = 1; i <= Height; i++)
            {
                //Display columns
                for (int j = 1; j <= i; j++)
                {
                  Console.Write("*") ;
                }
                //Go to the next line
                Console.WriteLine();
            }
            Console.ReadLine();
        }

    }
}
