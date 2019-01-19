using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_03_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            while (counter<=10)
            {
                int x = 1;
                for (int i = 0; i < counter; i++)
                {
                    x *=2;
                }
                Console.WriteLine("2 в степени {0} равно {1}",counter,x);
                counter++;
            }
            Console.ReadKey();
        }
    }
}
