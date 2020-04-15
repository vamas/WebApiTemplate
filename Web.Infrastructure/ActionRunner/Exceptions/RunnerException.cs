using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Infrastructure.ActionRunner.Exceptions
{
    [Serializable]
    public class RunnerException : Exception
    {
        public RunnerException()
            : base("Action runner error encountered")
        {
        }

        public RunnerException(string message)
            : base(message)
        {
        }

        public RunnerException(string message, Exception inner)
           : base(message, inner)
        {
        }

        protected RunnerException(System.Runtime.Serialization.SerializationInfo serializationInfo, 
            System.Runtime.Serialization.StreamingContext streamingContext)
        {
        }
    }
}