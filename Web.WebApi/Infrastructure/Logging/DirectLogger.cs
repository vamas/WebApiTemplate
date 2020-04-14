using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bayer.MyBayer.WebApi.Infrastructure.Logging
{
    public class DirectLogger : ILogger
    {
        private readonly ILog _logger;
        public DirectLogger()
        {
            XmlConfigurator.Configure();
            var logManager = new LogManagerAdapter();
            _logger = logManager.GetLog(typeof(DirectLogger));
        }

        public void Info(string message, Exception exception)
        {
            _logger.Info(message, exception);
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Debug(string message, Exception exception)
        {
            _logger.Debug(message, exception);
        }

        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Warning(string message, Exception exception)
        {
            _logger.Warn(message, exception);
        }

        public void Warning(string message)
        {
            _logger.Warn(message);
        }

        public void Error(string message, Exception exception)
        {
            _logger.Error(message, exception);
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }
    }
}