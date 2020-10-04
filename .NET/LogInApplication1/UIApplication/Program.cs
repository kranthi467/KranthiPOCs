using System;

/// <summary>
/// Presetation layer of the LogIn Application.
/// </summary>
namespace UIApplication
{
    /// <summary>
    /// Main class to take in option for operation.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main method to take options.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nEnter your option,");
                Console.WriteLine("1-Register\n2-Log in\n3-Forgot Password");
                Option option;

                try
                {
                    option = (Option)Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    option = Option.NONE;
                }

                InputOutput inOut = new InputOutput();

                switch (option)
                {
                    case Option.REGISTER:
                        inOut.Register();
                        break;
                    case Option.LOGIN:
                        inOut.LogIn();
                        break;
                    case Option.FORGOTPASSWORD:
                        inOut.ForgotPassword();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Enter correct option");
                        break;
                }
            }
        }
    }
}
