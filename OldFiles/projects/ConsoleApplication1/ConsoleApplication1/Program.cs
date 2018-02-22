using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new string[100];
            int i = 0;
            bool t = true;
            while (t)
            {
                a[i] = Console.ReadLine();
                if (a[i] != "a")
                {
                    i++;
                }
                else
                {
                    t = false;
                }
            }
            foreach (var item in a)
            {
                int s = Convert.ToInt32(item.Trim());
                Console.WriteLine(s);
            }
            Console.ReadLine();
        }
    }
}

