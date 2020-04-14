using Bayer.MyBayer.WebApi.Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bayer.MyBayer.WebApi.Infrastructure.Validation
{
    public class ValidationAttributeBase : ValidationAttribute
    {

        public ILogger Logger { get; private set; }

        public ValidationAttributeBase() 
        {
            this.Logger = new DirectLogger();
        }
    }
}