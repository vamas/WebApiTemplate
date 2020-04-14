using Bayer.MyBayer.WebApi.Controllers;
using Bayer.MyBayer.WebApi.Infrastructure.Facilities;
using Bayer.MyBayer.WebApi.Services;
using Bayer.MyBayer.WebApi.Services.Definitions;
using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bayer.MyBayer.WebApi.Infrastructure.Windsor
{
    public class ComponentRegistration : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var isSSHEnabled = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSSHEncryptedToken"]);
            var encryptionPassword = ConfigurationManager.AppSettings["EncryptionPassword"];
            var tokenLifespan = Convert.ToInt32(ConfigurationManager.AppSettings["ConfirmationTokenLifespan"]);
            var tokenVersion = Convert.ToInt32(ConfigurationManager.AppSettings["TokenVersion"]);

            //container.Register(
            //    Types.FromThisAssembly().InSameNamespaceAs<GrowerController>()
            //    .If(c => c.Name.EndsWith("Controller"))
            //    .Configure(x => x.LifestylePerWebRequest()));
            //container.AddFacility<LoggingFacility>(f => f.UseLog4Net());
            
            if (isSSHEnabled)
                container.Register(Component.For<IEncodingService>()
                .ImplementedBy(typeof(EncodingServiceSHA))
                .DependsOn(Dependency.OnValue("password", encryptionPassword))
                .LifeStyle.Singleton);
            else
                container.Register(Component.For<IEncodingService>()
                .ImplementedBy(typeof(EncodingServiceSimple))
                .LifeStyle.Singleton);

            container.Register(Component.For<IGrowerConsentService>()
                .ImplementedBy(typeof(GrowerConsentService)).LifeStyle.PerWebRequest);

            container.Register(Component.For<IConfirmationTokenService>()
                .ImplementedBy(typeof(ConfirmationTokenService))
                .DependsOn(Dependency.OnValue("tokenLifespan", tokenLifespan))
                .DependsOn(Dependency.OnValue("tokenVersion", tokenVersion))
                .LifeStyle.PerWebRequest);

            container.AddFacility<EntityFrameworkFacility>();
        }
    }
}