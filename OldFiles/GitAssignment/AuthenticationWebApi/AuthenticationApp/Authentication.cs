using BusinessLayer;
using System;
using DTO;
using System.Threading.Tasks;

namespace AuthenticationApp
{
    class Authentication
    {
      public   async Task DoAuthentication()
        {
            Console.WriteLine("enter 1:Register 2:Login 3:ForgotPassword");
            int choice = Convert.ToInt32(Console.ReadLine());
            string result;
            switch (choice)
            {
                case 1:
                    User newUser = ReadCredentials();
                    result = await BusinessClass.Register(newUser);
                    Console.WriteLine(result);
                    break;

                case 2:
                    User userObj = ReadCredentials();
                    result = await BusinessClass.Login(userObj);
                    Console.WriteLine(result);
                    break;

                case 3:
                    string username = Console.ReadLine();
                    result = await BusinessClass.GetPassword(username);
                    Console.WriteLine(result);
                    break;
            }
        }

        User ReadCredentials()
        {
            User userObj = new User();
            Console.WriteLine("enter username");
            userObj.Username = Console.ReadLine();        
            Console.WriteLine("Enter Password");
            userObj.Password = Console.ReadLine();
            return userObj;
        }

    }
}
