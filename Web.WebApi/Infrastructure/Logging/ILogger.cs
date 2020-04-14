using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bayer.MyBayer.WebApi.Infrastructure.Logging
{
    public interface ILogger
    {
        void Info(string message, Exception exception);
        void Info(string message);
        void Debug(string message, Exception exception);
        void Debug(string message);
        void Warning(string message, Exception exception);
        void Warning(string message);
        void Error(string message, Exception exception);
        void Error(string message);
    }
}
