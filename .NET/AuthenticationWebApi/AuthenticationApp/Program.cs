using System;

namespace AuthenticationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Authentication authenticationObj = new Authentication();
                authenticationObj.DoAuthentication().Wait();
                            
        }
       
    }
}
