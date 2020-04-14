using Bayer.MyBayer.WebApi.Infrastructure.Windsor;
using Bayer.MyBayer.WebApi.Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Bayer.MyBayer.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            string[] assemblies = {
                "Bayer.MyBayer.WebApi"
            };

            Container.InitializeContainer(assemblies);
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new WindsorHttpControllerActivator(Inject.GetContainer()));
        }

        protected void Application_Error()
        {
            var exception = Server.GetLastError();
            if (exception != null)
            {
                var log = new DirectLogger();
                log.Error("Unhandled exception.", exception);
            }
        }
    }
}
