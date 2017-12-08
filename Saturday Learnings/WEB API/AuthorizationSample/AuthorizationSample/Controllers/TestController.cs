using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AuthorizationSample.Controllers
{
    public class TestController : ApiController
    {
        [Authorize(Roles ="admin")]
        public string Get()
        {
            //return Ok("admin");
            return "only admin can access this";
        }

        [Authorize(Users ="bhavitha")]
        [Route("api/GetValues")]
        public string GetValues()
        {
            return "only specific users has access to it";
        }
    }
}
