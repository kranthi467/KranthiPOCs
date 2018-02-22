using DataAccess;
using Model;

namespace Business
{
    /// <summary>
    /// class to Authenticate user for usage of application
    /// </summary>
    class Authenticate : IAuthenticate
    {
        DataFactory factoryObject = new DataFactory();

        /// <summary>
        /// A method to Regester the user and returns True if sucessfull
        /// </summary>
        /// <param name="modelObject"></param>
        /// <returns></returns>
        public bool Register(RegisterModel modelObject)
        {
            if (modelObject.password == modelObject.reTyped)
            {
                IData inObject = factoryObject.GetData();

                if (!(inObject.CheckUser(modelObject.userName)))
                {
                    if (inObject.StoreData(modelObject))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// A method to logIn the user and returns True if sucessfull
        /// </summary>
        /// <param name="modelObject"></param>
        /// <returns></returns>
        public bool LogIn(LogInModel modelObject)
        {
            IData checkLog = factoryObject.GetData();

            if (checkLog.CheckUser(modelObject.userName))
            {
                if (checkLog.LogInCheck(modelObject))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// A method to Retrive password of the user and returns password if sucessfull else returns null
        /// </summary>
        /// <param name="modelObject"></param>
        /// <returns></returns>
        public string Password(ForgotPasswordModel modelObject)
        {
            IData password = factoryObject.GetData();

            if (password.CheckUser(modelObject.userName))
            {
                return password.GetPassword(modelObject);
            }

            return null;
        }
    }
}
