using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;
using System.Web.Http.Cors;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace WebApi_Sample
{

    //public class CustomJsonFormatters : JsonMediaTypeFormatter
    //{
    //    public CustomJsonFormatters()
    //    {
    //        this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
    //    }
    //    public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
    //    {
    //        base.SetDefaultContentHeaders(type, headers, mediaType);
    //        headers.ContentType = new MediaTypeHeaderValue("application/json");
    //    }
    //}
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //Enabling CORS and showing in controller level
            //config.EnableCors();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new
                {
                    id = RouteParameter.Optional,
                   }
            );


         //  config.Formatters.Add(new CustomJsonFormatters());

            //Enable Cors for entire Application (i.e: for all controllers and all methods)
           EnableCorsAttribute cors = new EnableCorsAttribute("*","*","*");
            config.EnableCors(cors);

            //Removing Formatters
            //In Postman and browser we can restrict the content type.
            config.Formatters.Remove(config.Formatters.JsonFormatter);
           // config.Formatters.Remove(config.Formatters.XmlFormatter);
           

            //App1
         //  config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));

            //config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json;
        }
    }
}
