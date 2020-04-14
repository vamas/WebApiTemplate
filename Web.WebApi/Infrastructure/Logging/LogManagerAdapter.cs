using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;

namespace Bayer.MyBayer.WebApi.Infrastructure.Logging
{
    public class LogManagerAdapter : ILogManager
    {
        public ILog GetLog(Type typeAssociatedWithRequestedLog)
        {
            var log = LogManager.GetLogger(typeAssociatedWithRequestedLog);
            return log;
        }
    }
}