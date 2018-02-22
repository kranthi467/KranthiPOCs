using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApiUsingEntity.Controllers
{
    public class UserCredentialsController : ApiController
    {
        public  string Get(string username)
        {

            UserCredentialsEntities userContextObj = new UserCredentialsEntities();
            var query = from user in userContextObj.UserDetails where user.username == username select user;
            try
            {
                UserDetail userObj = query.FirstOrDefault();
                if (userObj != null)
                {
                    return userObj.password;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.InnerException);
            }
            
            

            return "Invalid username";
        }
        [Route("api/UserCredentials/{username}/{password}")]
        public string Get(string username,string password)
        {
            UserCredentialsEntities userContextObj = new UserCredentialsEntities();
            var query = from user in userContextObj.UserDetails where user.username == username select user;
            
            UserDetail userObj = query.FirstOrDefault();
            if (userObj != null)
            {
                if (userObj.password == password)
                    return "Login Successful";
                else
                    return "Login unsuccessful. Check your password";
            }


            return "Invalid username";
        }
        public void Post([FromBody]UserDetail value)
        {
            UserCredentialsEntities userContextObj = new UserCredentialsEntities();
            UserDetail userObj = new UserDetail();
            userObj.username = value.username;
            userObj.password = value.password;
            try
            {
                userContextObj.UserDetails.Add(userObj);
                userContextObj.SaveChanges();
                Console.WriteLine( "Registration Successful");
            }
            catch (Exception e)
            {
                Console.WriteLine( " Registration Unsuccessful.User already exists");
            }
        }

    }
}
