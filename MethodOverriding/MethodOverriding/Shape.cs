using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodOverriding
{
    public class Shape
    {
        public int Height { get; set; }
        public int Widht { get; set; }
        public Position Position { get; set; }

        //kann keinen Body haben, implementieren die derived klasse
     //   public abstract void Draw();

        public virtual void Draw()
        {

        }
    }
}
