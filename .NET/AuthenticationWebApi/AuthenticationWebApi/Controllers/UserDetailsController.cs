using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AuthenticationWebApi;

namespace AuthenticationWebApi.Controllers
{
    public class UserDetailsController : ApiController
    {
        private UserCredentialsEntities userContextObj = new UserCredentialsEntities();

        

        // GET: api/UserDetails/5
       // [ResponseType(typeof(UserDetail))]
        public async Task<String> GetUserPassword(string id)
        {
            UserDetail userDetail = await userContextObj.UserDetails.FindAsync(id);
            if (userDetail == null)
            {
                return "Invalid Username";
            }

            return userDetail.password;
        }

        [Route("api/UserDetails/{username}/{password}")]
        public async Task<string> Get(string username, string password)
        {
            UserDetail userDetail = await userContextObj.UserDetails.FindAsync(username);
            if (userDetail == null)
            {
                return "Invalid Username.";
            }
            else if (userDetail.password.Equals(password))
            {
                return "Login successful.";
            }

            return "Login Unsuccessful. Check password.";
        }

       
        public async Task<IHttpActionResult> PostUserDetail([FromBody]UserDetail userDetail)
        {
            
            userContextObj.UserDetails.Add(userDetail);

            try
            {
                await userContextObj.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserDetailExists(userDetail.username))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            
            return Ok();
           
        }


     

        private bool UserDetailExists(string id)
        {
            return userContextObj.UserDetails.Count(e => e.username == id) > 0;
        }
    }
}