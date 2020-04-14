using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Swashbuckle.Swagger;
using System.Web.Http.ExceptionHandling;
using Bayer.MyBayer.WebApi.ErrorHandling;
using Bayer.MyBayer.WebApi.Infrastructure.ErrorHandling;

namespace Bayer.MyBayer.WebApi
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
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Services.Add(typeof(IExceptionLogger),
                new SimpleExceptionLogger());

            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());
            //Swashbuckle.Bootstrapper.Init(config);

            EnableCors(config);

        }

        private static void EnableCors(HttpConfiguration config)
        {
            EnableCorsAttribute cors = new EnableCorsAttribute("*", "POST", "*");
            config.EnableCors(cors);
        }
    }
}
