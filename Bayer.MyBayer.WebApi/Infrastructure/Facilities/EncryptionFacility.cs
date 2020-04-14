using Bayer.MyBayer.WebApi.DAL;
using Bayer.MyBayer.WebApi.Services.Definitions;
using Bayer.MyBayer.WebApi.Services;
using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bayer.MyBayer.WebApi.Infrastructure.Facilities
{
    public class EncryptionFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.Register(
                Component.For<IEncodingService>()
                .ImplementedBy<EncodingServiceSHA>()
                .LifestyleSingleton()
                );
        }
    }
}


