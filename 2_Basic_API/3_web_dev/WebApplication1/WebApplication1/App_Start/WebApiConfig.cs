using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApplication1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            //configuring cors 
            //global cors configuration (lowest priority)
            EnableCorsAttribute globalCors = new EnableCorsAttribute("*", "*", "*"); // origin (host), header, Http_methods
            config.EnableCors(globalCors);

            //setting cors for specific domain (higher priority then globalCors)
            EnableCorsAttribute localCors = new EnableCorsAttribute("https://localhost:44300/", "*", "GET");
            config.EnableCors(localCors);

            // other is action and controller level cors

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Routes.MapHttpRoute(
            //    name: "version2",
            //    routeTemplate:"api/v2/{contorller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            // );
        }
    }
}
