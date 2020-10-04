using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace WebAPIFileUploadDownload.Controllers
{
    public class ImageController : ApiController
    {
        // GET: api/Image
        public IEnumerable<string> Get()
        {
            return new string[] { "get request" };
        }

        // GET: api/Image/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Image
        public void Post()
        {
            try
            {
                System.Web.HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;

                if (files.Count > 0)
                {
                    System.Web.HttpPostedFile file = files[0];
                    file.SaveAs(@"C:\Users\bhavitha.annam\Pictures\hello.jpg");
                 }
            }
            catch(Exception ex)
            {
            }
        }

        // PUT: api/Image/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Image/5
        public void Delete(int id)
        {
        }
    }
}
