using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Bayer.MyBayer.WebApi.Infrastructure.Windsor
{
    public class WindsorHttpControllerActivator : IHttpControllerActivator
    {
        private IWindsorContainer _container;

        public WindsorHttpControllerActivator(IWindsorContainer container)
        {
            _container = container;
        }
 
        public IHttpController Create(
            HttpRequestMessage request,
            HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            var controller =
                (IHttpController)_container.Resolve(controllerType);
 
            request.RegisterForDispose(
                new Release(
                    () => _container.Release(controller)));
 
            return controller;
        }
 
        private class Release : IDisposable
        {
            private readonly Action release;
 
            public Release(Action release)
            {
                this.release = release;
            }
 
            public void Dispose()
            {
                this.release();
            }
        }
    }
}