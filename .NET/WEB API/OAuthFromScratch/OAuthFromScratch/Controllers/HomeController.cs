using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OAuthFromScratch.Controllers
{
    [Authorize]
     public class HomeController : ApiController
    {
        public IHttpActionResult Get()
        {
            var user = Request.GetOwinContext().Authentication.User;
            return Ok("Hello Web Api");
        }
    }
}
