using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bayer.MyBayer.WebApi.Infrastructure.ErrorHandling.Exceptions
{
	public class ConsentNotFoundException : Exception
	{
        public ConsentNotFoundException()
            : base("No unconfirmed consent found for the provided token")
        {
        }

        public ConsentNotFoundException(string message)
			: base(message)
		{
		}

         public ConsentNotFoundException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}

}

