using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference2.IService1 referenceObj = new ServiceReference2.Service1Client();
            var greeting = referenceObj.GetGreeting("Priyanka");
            Console.WriteLine(greeting);
            Console.Read();
        }
    }
}
