using System.Collections.Generic;
using Model;

namespace DataAccess
{
    /// <summary>
    /// class to store and retrive data of users
    /// </summary>
    internal class Data : IData
    {
        static Dictionary<string, string> logInInfo = new Dictionary<string, string>();
        static Dictionary<string, string> forgotInfo = new Dictionary<string, string>();

        /// <summary>
        /// A method to check wheather user is available or not
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool CheckUser(string userName)
        {
            if (logInInfo.ContainsKey(userName))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// A method to store user details. If sucessful returns True
        /// </summary>
        /// <param name="modelObject"></param>
        /// <returns></returns>
        public bool StoreData(RegisterModel modelObject)
        {
            try
            {
                logInInfo.Add(modelObject.userName, modelObject.password);
                forgotInfo.Add(modelObject.userName, modelObject.phoneNo);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// a method to return password if details provided are correct
        /// </summary>
        /// <param name="modelObject"></param>
        /// <returns></returns>
        public string GetPassword(ForgotPasswordModel modelObject)
        {
            string temp = string.Empty;
            forgotInfo.TryGetValue(modelObject.userName, out temp);

            if (temp == modelObject.phoneNo)
            {
                logInInfo.TryGetValue(modelObject.userName, out temp);
                return temp;
            }

            return null;
        }

        /// <summary>
        /// A method to verify password and logIn the user
        /// </summary>
        /// <param name="modelObject"></param>
        /// <returns></returns>
        public bool LogInCheck(LogInModel modelObject)
        {
            string temp;
            logInInfo.TryGetValue(modelObject.userName, out temp);

            if (modelObject.password == temp)
            {
                return true;
            }

            return false;
        }
    }
}
