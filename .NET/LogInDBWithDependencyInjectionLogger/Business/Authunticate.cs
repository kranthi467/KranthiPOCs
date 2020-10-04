using DataAccess;
using Model;
using System;
using Microsoft.Practices.Unity;

namespace Business
{
    /// <summary>
    /// class to Authenticate user for usage of application
    /// </summary>
    class Authenticate : IAuthenticate
    {
        DataFactory factoryObject = new DataFactory();
        IUnityContainer unitycontainer1 = new UnityContainer();
        IUnityContainer unitycontainer2 = new UnityContainer();
        Logger log = new Logger();
        Logger log2 = new Logger();

        public Authenticate()
        {
            unitycontainer1.RegisterType<ILog, Log>();
            log = unitycontainer1.Resolve<Logger>();
            unitycontainer2.RegisterType<ILog, LogText>();
            log2 = unitycontainer2.Resolve<Logger>();
        }

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
                try
                {
                    if (!(inObject.CheckUser(modelObject.userName)))
                    {
                        if (inObject.StoreData(modelObject))
                        {
                            log2.EventLogger(new EventLog()
                            {
                                userName = modelObject.userName,
                                Event = "Registered user"
                            });
                            return true;
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    log.EventLogger(new EventLog()
                    {
                        userName = modelObject.userName
                    },ex);
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

            try
            {
                if (checkLog.CheckUser(modelObject.userName))
                {
                    if (checkLog.LogInCheck(modelObject))
                    {
                        log.EventLogger(new EventLog()
                        {
                            userName = modelObject.userName,
                            Event = "Loging user"
                        });
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                log.EventLogger(new EventLog()
                {
                    userName = modelObject.userName
                }, ex);
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

            try
            {
                if (password.CheckUser(modelObject.userName))
                {
                    log.EventLogger(new EventLog()
                    {
                        userName = modelObject.userName,
                        Event = "Getting password of user"
                    });
                    return password.GetPassword(modelObject);
                }
            }
            catch (Exception ex)
            {
                log.EventLogger(new EventLog()
                {
                    userName = modelObject.userName
                }, ex);
            }
            return null;
        }
    }
}
