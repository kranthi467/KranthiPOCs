using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication3.App_Start
{
    public class HttpMessageLogger : DelegatingHandler
    {
        private HttpMessageLogEntities _db;
        private RequestsLog _requestObj;
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            if (!request.RequestUri.ToString().Contains ("http://localhost:60307/swagger"))
            {
                try
                {
                    using (_db = new HttpMessageLogEntities())
                    {
                        _requestObj = new RequestsLog();

                        if (request.Headers.Contains("Origin") && request.Headers.GetValues("Origin") != null && request.Headers.Referrer!=null)
                        {
                        _requestObj.Origin = request.Headers.GetValues("Origin").FirstOrDefault();
                            _requestObj.Referer = request.Headers.Referrer.ToString();
                        }

                        _requestObj.Host = request.Headers.Host;
                        
                        _requestObj.RequestMethod = request.Method.ToString();
                        _requestObj.RequestURL = request.RequestUri.ToString();
                        _requestObj.UserAgent = request.Headers.UserAgent.ToString();
                        _db.RequestsLogs.Add(_requestObj);
                        _db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return base.SendAsync(request, cancellationToken);

        }

    }
}