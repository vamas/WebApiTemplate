using System;
using System.Collections.Generic;
using System.Text;
using Web.Infrastructure.ActionRunner.Interface;
using Web.Infrastructure.BusinessLogic.Model;

namespace Web.Infrastructure.ActionQueue
{
    public class ActionQueueEntry<TIn, TOut>
        where TIn : BusinessLogicEntity
        where TOut : BusinessLogicEntity
    {
        public BusinessAction<TIn, TOut> actionClass { get; set; }
        public TIn dataIn { get; set; }
        public ActionExecStatus execStatus { get; set; }

        public BusinessAction<TIn, TOut> rollbackActionClass { get; set; }
        public TIn rollbackDataIn { get; set; }
        public ActionExecStatus rollbackExecStatus { get; set; }
    }
}
