using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace Bayer.MyBayer.WebApi.ErrorHandling
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        private const string ERROR_MESSAGE = "An error has occured while processing you request. Please retry the request or check with the service desk to resolve your issue.";
        public override bool ShouldHandle(ExceptionHandlerContext context)
        {
            return true;
        }

        public override void Handle(ExceptionHandlerContext context)
        {
            var exception = context.Exception;

            var httpException = exception as HttpException;
            if (httpException != null)
            {
                context.Result = new SimpleErrorResult(context.Request,
                    (HttpStatusCode)httpException.GetHttpCode(), httpException.Message);
                return;
            }

            //if (exception is )
            //{
            //    context.Result = new SimpleErrorResult(context.Request, HttpStatusCode.Unauthorized,
            //        exception.Message);
            //    return;
            //}

            context.Result = new SimpleErrorResult(context.Request, HttpStatusCode.InternalServerError, ERROR_MESSAGE);
        }
    }
}