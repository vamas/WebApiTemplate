using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bayer.MyBayer.WebApi.Infrastructure.ErrorHandling.Exceptions
{
	public class GrowerConsentExistsException : Exception
	{
        public GrowerConsentExistsException()
            : base("The email provided already associated with existing grower consent")
        {
        }

        public GrowerConsentExistsException(string message)
			: base(message)
		{
		}

         public GrowerConsentExistsException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}

}

