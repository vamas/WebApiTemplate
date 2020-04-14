using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bayer.MyBayer.WebApi.Infrastructure.ErrorHandling.Exceptions
{
	public class ConfirmationTokenExpiredException : Exception
	{
        public ConfirmationTokenExpiredException()
            : base("Confirmation token is expired")
        {
        }

        public ConfirmationTokenExpiredException(string message)
			: base(message)
		{
		}

         public ConfirmationTokenExpiredException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}

}

