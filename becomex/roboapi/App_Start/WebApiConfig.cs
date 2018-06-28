using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace roboapi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                //routeTemplate: "api/{controller}/{funcao}/{id}",
                routeTemplate: "{controller}/{action}",
                defaults: new { id = RouteParameter.Optional }
            );


            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.Indent = true;
        }
    }
}
