using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
namespace PresentationLayer
{
    class Program
    {
        static  void  Main(string[] args)
        {
            try
            {
                Main1().Wait();
                Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.InnerException);
                Console.ReadKey();
            }
        

        }
        static async Task Main1()
        {
            Console.WriteLine("enter 1:Register 2:Login 3:ForgotPassword");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                   await BusinessClass.Post(Console.ReadLine());
                    break;

                case 2:
                    await BusinessClass.Get(Console.ReadLine());
                    
                    break;
                case 3:
                   await BusinessClass.Get(Console.ReadLine());
                   
                    break;
            }
        }
    }
}
