using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrator
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Users\Chris\Desktop\Test.txt";
            var mig = new DbMigrator(new FileLogger(path));
            mig.Migrate();
        }
    }
}
