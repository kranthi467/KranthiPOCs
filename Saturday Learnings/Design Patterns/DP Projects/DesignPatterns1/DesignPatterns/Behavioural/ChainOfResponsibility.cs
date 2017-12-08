using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Design_Patterns
{
    class Client
    {
        static void Main(string[] args)
        {
            HttpRequestMessage requestString = new HttpRequestMessage();
            SecurityHandler securityHandler = new SecurityHandler();
            LicenseHandler licenseHandler = new LicenseHandler();
            ApplicationHandler applicationHandler = new ApplicationHandler();

            securityHandler.NextHandler(licenseHandler);
            licenseHandler.NextHandler(applicationHandler);

            securityHandler.ProcessRequest(requestString);
        }
    }

    abstract class Handler
    {
        public Handler nextHandler;
        public void NextHandler(Handler handler)
        {
            this.nextHandler = handler;
        }

        abstract public HttpResponseMessage ProcessRequest(HttpRequestMessage request);
    }

    class SecurityHandler : Handler
    {
        public override HttpResponseMessage ProcessRequest(HttpRequestMessage request)
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage();

            Console.WriteLine("Request is handling by Security Handler");

            if (nextHandler != null)
            {
                responseMessage = nextHandler.ProcessRequest(request);
            }

            return responseMessage;
        }
    }


    class LicenseHandler : Handler
    {
        public override HttpResponseMessage ProcessRequest(HttpRequestMessage request)
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage();

            Console.WriteLine("Request is handling by License Handler");

            if (nextHandler != null)
            {
                responseMessage = nextHandler.ProcessRequest(request);
            }
            return responseMessage;
        }
    }

    class ApplicationHandler : Handler
    {
        public override HttpResponseMessage ProcessRequest(HttpRequestMessage request)
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage();

            Console.WriteLine("Request is handling by Application Handler");

            if (nextHandler != null)
            {
                nextHandler.ProcessRequest(request);
            }
            else
            {

                responseMessage = new HttpResponseMessage();
            }

            return responseMessage;
        }
    }

}