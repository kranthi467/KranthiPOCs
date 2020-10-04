using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_Sample.Models;

namespace WebApi_Sample.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        [HttpPost]
        [Route("save")]
        public HttpResponseMessage save(Account account)
        {
            try
            {
                if(account!=null && account.UserName.Equals("abc"))
                {
                    ModelState.AddModelError("account.username", "UserName Already Exists");
                }
                if (ModelState.IsValid)
                {
                    //return new HttpResponseMessage(HttpStatusCode.OK);

                    return Request.CreateResponse(HttpStatusCode.OK, "Validation Success");
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
    }
}
