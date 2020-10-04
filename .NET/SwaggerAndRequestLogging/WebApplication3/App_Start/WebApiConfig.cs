using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApplication3.App_Start;

namespace WebApplication3
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            var corsAttr = new System.Web.Http.Cors.EnableCorsAttribute("http://localhost:8009", "*", "*");
            corsAttr.PreflightMaxAge = int.MaxValue;
            config.EnableCors(corsAttr);
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.MessageHandlers.Add(new HttpMessageLogger());
        }
    }
}
