#region NameSpaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices.Protocols;
using System.Net;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices.AccountManagement;
#endregion

namespace ActiveDirectoryLogin
{
    class Program
    {
        #region Validating User
        /// <summary>
        /// Validation for a single user to the active directory
        /// </summary>
        /// <returns></returns>
        public static bool fnValidateUser()
        {
            bool validation;
            try
            {
                LdapConnection lcon = new LdapConnection(new LdapDirectoryIdentifier((string)null, false, false));
                NetworkCredential nc = new NetworkCredential(Environment.UserName, "kals123", Environment.UserDomainName);
                lcon.Credential = nc;
                lcon.AuthType = AuthType.Negotiate;
                lcon.Bind(nc); // user has authenticated at this point, as the credentials were used to login to the dc.
                validation = true;
            }
            catch (LdapException)
            {
                validation = false;
            }
            return validation;
        }
        #endregion

        #region Listing All Users
        /// <summary>
        /// Lists all the users from current domain
        /// </summary>
        public static void fnListAllUser()
        {
            try
            {
                DirectoryEntry directoryEntry = new DirectoryEntry("WinNT://" + Environment.UserDomainName);
                string userNames = "";
                string authenticationType = "";
                foreach (DirectoryEntry child in directoryEntry.Children)
                {
                    if (child.SchemaClassName == "User")
                    {
                        userNames += child.Name + Environment.NewLine; //Iterates and binds all user using a newline
                        authenticationType += child.Username + Environment.NewLine;
                    }
                }
                Console.WriteLine("************************Users************************");
                Console.WriteLine(userNames);
                Console.WriteLine("*****************Authentication Type*****************");
                Console.WriteLine(authenticationType);
            }
            catch (Exception)
            {
                Console.WriteLine("Network error occured.");
            }
        }
        #endregion

        #region user names with groups
        /// <summary>
        /// Getting user names with respective groups
        /// </summary>
        public static void fnGetListOfUsers()
        {
            try
            {
                // set up domain context
                PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
                // find the group in question
                GroupPrincipal group = GroupPrincipal.FindByIdentity(ctx, "USERS");
                // if found....
                if (group != null)
                {
                    // iterate over members
                    foreach (Principal p in group.GetMembers())
                    {
                        Console.WriteLine("{0}: {1}", p.StructuralObjectClass, p.DisplayName);
                        // do whatever you need to do to those members
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Network error occured.");
            }
        }
        #endregion

        #region User Details from AD
        /// <summary>
        /// Getting a particular user details from user's active directory
        /// </summary>
        public static void fnImp()
        {
            try
            {
                using (var context = new PrincipalContext(ContextType.Domain, Environment.UserDomainName))
                {
                    using (var searcher = new PrincipalSearcher(new UserPrincipal(context)))
                    {
                        foreach (var result in searcher.FindAll())
                        {
                            DirectoryEntry de = result.GetUnderlyingObject() as DirectoryEntry;
                            if ((string)de.Properties["givenName"].Value == Environment.UserName)
                            {
                                //Console.WriteLine("First Name: " + de.Properties["givenName"].Value);
                                //Console.WriteLine("Last Name : " + de.Properties["sn"].Value);
                                //Console.WriteLine("SAM account name   : " + de.Properties["samAccountName"].Value);
                                //Console.WriteLine("User principal name: " + de.Properties["userPrincipalName"].Value);
                                Console.WriteLine();
                                PropertyCollection pc = de.Properties;
                                foreach (PropertyValueCollection col in pc)
                                {
                                    Console.WriteLine(col.PropertyName + " : " + col.Value);
                                    Console.WriteLine();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Network error occured.");
            }
        }
        #endregion

        #region Main
        static void Main(string[] args)
        {
            using (var pc = new PrincipalContext(ContextType.Domain, Environment.UserDomainName))
            {
                using (var up = new UserPrincipal(pc))
                {
                    up.SamAccountName = "Kranthi";
                    up.EmailAddress = "kranthi.ramasayam@ggktech.com";
                    up.SetPassword("Hyderabad123");
                    up.Enabled = true;
                    up.ExpirePasswordNow();
                    up.Save();
                }
            }
            fnListAllUser();
            fnImp();
            fnGetListOfUsers();
            Console.WriteLine(fnValidateUser());
        }
        #endregion
    }
}
