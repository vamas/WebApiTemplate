using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bayer.MyBayer.WebApi.Infrastructure.ErrorHandling.Exceptions
{
	public class InvalidConfirmationTokenException : Exception
	{
        public InvalidConfirmationTokenException()
            : base("Invalid confirmation token provided")
        {
        }

        public InvalidConfirmationTokenException(string message)
			: base(message)
		{
		}

         public InvalidConfirmationTokenException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}

}

