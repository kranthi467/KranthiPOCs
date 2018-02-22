using System;
using Business;
using Model;

namespace UIApplication
{
    /// <summary>
    /// Class to take input and print related ouput  
    /// </summary>
    class InputOutput
    {
        BusinessFactory factoryObject = new BusinessFactory();

        /// <summary>
        /// Method to take input and output for registration of user
        /// </summary>
        public void Register()
        {
            RegisterModel modelObject = new RegisterModel();
            IAuthenticate setter = factoryObject.GetBusiness();

            Console.Clear();
            Console.Write("userName:");
            modelObject.userName = Console.ReadLine();
            Console.Write("Password:");
            modelObject.password = Console.ReadLine();
            Console.Write("ReEnter :");
            modelObject.reTyped = Console.ReadLine();
            Console.Write("Phone no:");
            modelObject.phoneNo = Console.ReadLine();

            if (setter.Register(modelObject))
            {
                Console.WriteLine("Registered Successfully");
            }
            else
            {
                Console.WriteLine("Check retyped password or user already exists");
            }
        }

        /// <summary>
        /// Method to take input of logIn details
        /// </summary>
        public void LogIn()
        {
            LogInModel modelObject = new LogInModel();
            IAuthenticate setter = factoryObject.GetBusiness();

            Console.Clear();
            Console.Write("userName:");
            modelObject.userName = Console.ReadLine();
            Console.Write("Password:");
            modelObject.password = Console.ReadLine();

            if (setter.LogIn(modelObject))
            {
                Console.WriteLine("Welcome  " + modelObject.userName);

            }
            else
            {
                Console.WriteLine("Check ...");
            }
        }

        /// <summary>
        /// Method to take input details for password retrival and print password
        /// </summary>
        public void ForgotPassword()
        {
            ForgotPasswordModel modelObject = new ForgotPasswordModel();
            IAuthenticate setter = factoryObject.GetBusiness();

            Console.Clear();
            Console.Write("userName:");
            modelObject.userName = Console.ReadLine();
            Console.Write("Phone no:");
            modelObject.phoneNo = Console.ReadLine();

            string password = setter.Password(modelObject);

            if (password != null)
            {
                Console.WriteLine(password);
            }
            else
            {
                Console.WriteLine("No Login");
            }
        }
    }
}
