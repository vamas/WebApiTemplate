using System;
using System.Collections.Generic;
using System.Text;
using Web.Infrastructure.Exceptions;

namespace Web.Services.Exceptions
{
    public class NotFoundException : BusinessException
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}