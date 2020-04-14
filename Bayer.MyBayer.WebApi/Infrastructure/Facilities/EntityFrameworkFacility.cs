using Bayer.MyBayer.WebApi.DAL;
using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bayer.MyBayer.WebApi.Infrastructure.Facilities
{
    public class EntityFrameworkFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.Register(
                Component.For<IDbContext>()
                .ImplementedBy<GrowerDbContext>()
                .LifestylePerWebRequest()
                );
        }
    }
}