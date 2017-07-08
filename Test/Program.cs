using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            int x = 10;
            int y;
            y = x++;
            Console.WriteLine("{0}, {1}", x, y);
            x = 20;
            y = ++x;
            Console.WriteLine("After prefic {0}, {1}", x, y);

            Console.Read();
        }
    }
}
