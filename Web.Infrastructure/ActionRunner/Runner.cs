using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Web.Infrastructure.ActionRunner.Exceptions;
using Web.Infrastructure.BusinessLogic.Interface;
using Web.Infrastructure.BusinessLogic.Model;

namespace Web.Infrastructure.ActionRunner
{
    public class Runner<TIn, TOut> : RunnerBase<TIn, TOut>
        where TIn: BusinessLogicEntity
        where TOut: BusinessLogicEntity
    {
        public Runner(IBusinessLogicData repo) : base(repo)
        {
        }

        public override async Task<IList<TOut>> RunActionQueueAsync()
        {
            var result = new List<TOut>();
            foreach (var runnerActionEntry in ActionQueue)
            {
                result.Add(await runnerActionEntry.actionClass.Action(runnerActionEntry.dataIn));
                if (HasErrors)
                {
                    runnerActionEntry.execStatus = ActionExecStatus.Error;
                    await RollbackActionQueueAsync();
                    return null;
                }
                runnerActionEntry.execStatus = ActionExecStatus.Success;
                runnerActionEntry.rollbackExecStatus = (runnerActionEntry.rollbackActionClass != null) 
                    ? ActionExecStatus.Queued : ActionExecStatus.NoAction;
            }
            return result;
        }

        public override async Task RollbackActionQueueAsync()
        {
            var result = new List<TOut>();
            for (int i = ActionQueue.Count - 1; i >= 0; i--)
            {
                var runnerActionEntry = ActionQueue[i];
                if (runnerActionEntry.rollbackExecStatus == ActionExecStatus.Queued)
                {
                    //Execute rollback action
                    result.Add(await runnerActionEntry.rollbackActionClass.Action(runnerActionEntry.rollbackDataIn));
                    if (HasRollbackErrors)
                    {
                        throw new RunnerException("Unrecoverable action runner error encountered. Manual cleanup on CDIP backend is required");
                    }
                    runnerActionEntry.execStatus = ActionExecStatus.Recovered;
                }
            }
        }
    }
}