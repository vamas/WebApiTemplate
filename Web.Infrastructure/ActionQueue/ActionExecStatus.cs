using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Infrastructure.ActionQueue
{
    public enum ActionExecStatus
    {
        NoAction = 0,
        Pending = 1,
        Success = 2,
        Error = 3,
        Recovered = 4
    }
}
