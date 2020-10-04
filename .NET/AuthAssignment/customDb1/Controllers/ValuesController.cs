using System;
using System.Web.Http;

namespace customDb1.Controllers
{
    [Authorize(Roles = "admin,dev,manager,director")]
    public class ValuesController : ApiController
    {
        [HttpGet]
        [AllowAnonymous]
        public string AnonymousAction()
        {
            return "Anonymous Action :" + DateTime.Now.ToString();
        }

        [HttpGet]

        [Route("api/values/useraction")]
        
        public string UserAction()
        {
            return "User Action :" + DateTime.Now.ToString();
        }

        [Authorize(Roles = "admin,director")]
        [HttpGet]
        [Route("api/values/AdminAction")]
        public string AdminAction()
        {
            return "Admin Action :" + DateTime.Now.ToString();
        }
    }
}
