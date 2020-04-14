
using Bayer.MyBayer.WebApi.Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bayer.MyBayer.WebApi.Infrastructure.Validation
{
    public static class ValidationError
    {
        public static ValidationResult LogResult(ILogger logger, string message)
        {
            Log(logger, message);
            return new ValidationResult(message);
        }
        private static void Log(ILogger logger, string message)
        {
            logger.Error(string.Format("Invalid data submitted: {0}", message));
        }
    }
}