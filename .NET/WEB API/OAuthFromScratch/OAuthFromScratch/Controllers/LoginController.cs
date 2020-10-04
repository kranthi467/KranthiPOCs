﻿using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace OAuthFromScratch.Controllers
{
    [AllowAnonymous]
    public class LoginController : ApiController
    {
        [HttpGet]
        public IHttpActionResult ExternalLogin()
        {
            return new ChallengeResult("Google", "/api/home", this.Request);
        }
    }
}
