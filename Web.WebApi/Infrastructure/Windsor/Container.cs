using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;

namespace Bayer.MyBayer.WebApi.Infrastructure.Windsor
{

    public static class Inject
    {
        private static IWindsorContainer _container;

        internal static void InitializeContainer(IWindsorContainer container)
        {
            _container = container;
        }

        public static T Resolve<T>()
        {
            var result = _container.Resolve<T>();
            return result;
        }

        public static void Release<T>(T instance)
        {
            _container.Release(instance);
        }
        public static IWindsorContainer GetContainer()
        {
            return _container;
        }
    }


    public static class Container
    {
        public static IWindsorContainer InitializeContainer(IEnumerable<string> assemblyNames)
        {
            var winsdorInstallerList = new List<IWindsorInstaller>();
            foreach(string assemblyName in assemblyNames)
            {
                winsdorInstallerList.Add(FromAssembly.Named(assemblyName));
            }

            IWindsorContainer windsorContainer = new WindsorContainer();
            InitializeIOCContainer(windsorContainer, winsdorInstallerList.ToArray());
            Inject.InitializeContainer(windsorContainer);
            return windsorContainer;

        }

        public static void InitializeIOCContainer(IWindsorContainer container, IWindsorInstaller[] installerList)
        {
            container.Install(installerList);
            container.Register(Component.For(typeof(IWindsorContainer)).Instance(container));
        }
    }
}