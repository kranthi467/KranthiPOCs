using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication3.Controllers
{
    [RoutePrefix("api/images")]
    public class ImagesController : ApiController
    {
        [HttpPost]
        [Route("upload")]
        public HttpResponseMessage uploadimage()
        {

            return Request.CreateResponse(HttpStatusCode.OK, "AS");
        }
        [HttpGet]
        [Route("getimages")]
        public HttpResponseMessage getimages()
        {

            return Request.CreateResponse(HttpStatusCode.OK, "AS");
        }

    }
}
