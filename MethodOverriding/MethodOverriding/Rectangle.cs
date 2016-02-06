using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodOverriding
{
    public class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Draw a Rectangle");
            //Display rows
            for (int i = 1; i <= Height; i++)
            {
                //Display columns
                for (int j = 1; j <= Widht; j++)
                {
                    if (i == Height || i == 1)
                        Console.Write("*");
                    else if (j == Widht || j == 1)
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                //Go to the next line
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
