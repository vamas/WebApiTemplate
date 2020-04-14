using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bayer.MyBayer.WebApi.Infrastructure.ErrorHandling.Exceptions
{
	public class StoredProcedureFailureException : Exception
	{
		 public StoredProcedureFailureException(string message)
			: base(message)
		{
		}

         public StoredProcedureFailureException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}

}

