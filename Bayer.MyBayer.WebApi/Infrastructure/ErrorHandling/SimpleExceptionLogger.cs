using Bayer.MyBayer.WebApi.Infrastructure.Logging;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace Bayer.MyBayer.WebApi.Infrastructure.ErrorHandling
{
    public class SimpleExceptionLogger : ExceptionLogger
    {
        private readonly DirectLogger _log;

        //public SimpleExceptionLogger(ILogManager logManager)
        //{
        //    _log = logManager.GetLog(typeof(SimpleExceptionLogger));
        //}

        public SimpleExceptionLogger()
        {
            _log = new DirectLogger();
        }

        public override void Log(ExceptionLoggerContext context)
        {
            _log.Error("Unhandled exception", context.Exception);
        }
    }
}