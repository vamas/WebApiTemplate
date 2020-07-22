using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Web.Infrastructure.ActionQueue;
using Web.Infrastructure.ActionRunner.Interface;
using Web.Infrastructure.BusinessLogic.Interface;
using Web.Infrastructure.BusinessLogic.Model;

namespace Web.Infrastructure.ActionRunner
{
    public abstract class RunnerBase<TIn, TOut>
        where TIn: BusinessLogicEntity
        where TOut: BusinessLogicEntity
    {
        //private IList<ActionQueueEntry<TIn, TOut>> _actionQueue;
        private ActionQueue.ActionQueue<TIn, TOut> _actionQueue;
        private readonly IBusinessLogicData _repo;

        public IImmutableList<ValidationResult> Errors
        {
            get
            {
                if (_actionQueue.Count != 0)
                {
                    IList<ValidationResult> errors = new List<ValidationResult>();
                    foreach (var runnerAction in _actionQueue)
                    {
                        errors = errors.Concat(runnerAction.actionClass.Errors).ToList();
                    }
                    return errors.ToImmutableList<ValidationResult>();
                }
                else
                    return  new List<ValidationResult>().ToImmutableList<ValidationResult>();
            }
        }
        public bool HasErrors => (Errors.Count == 0) ? false : true;

        public IImmutableList<ValidationResult> RollbackErrors
        {
            get
            {
                if (_actionQueue.Count != 0)
                {
                    IList<ValidationResult> errors = new List<ValidationResult>();
                    foreach (var rollbackRunnerAction in _actionQueue.Where(x => x.rollbackExecStatus == ActionExecStatus.Pending))
                    {
                        if(rollbackRunnerAction.rollbackActionClass != null)
                            errors = errors.Concat(rollbackRunnerAction.rollbackActionClass.Errors).ToList();
                    }
                    return errors.ToImmutableList<ValidationResult>();
                }
                else
                    return new List<ValidationResult>().ToImmutableList<ValidationResult>();
            }
        }
        public bool HasRollbackErrors => (RollbackErrors.Count == 0) ? false : true;

        public bool ActionQueueIsEmpty => !_actionQueue.Any();

        public RunnerBase(IBusinessLogicData repo)
        {
            _repo = repo;
            _actionQueue = new ActionQueue.ActionQueue<TIn, TOut>();
        }

        public void AddRunnerAction(
            BusinessAction<TIn, TOut> actionClass, TIn dataIn,
            BusinessAction<TIn, TOut> rollbackActionClass, TIn rollbackDataIn
            )
        {
            _actionQueue.Add(new ActionQueueEntry<TIn, TOut>
            {
                actionClass = actionClass,
                dataIn = dataIn,
                execStatus = ActionExecStatus.Pending,
                rollbackActionClass = rollbackActionClass,
                rollbackDataIn = rollbackDataIn,
                rollbackExecStatus = ActionExecStatus.NoAction
            });
        }
        public abstract Task<IList<TOut>> RunActionQueueAsync();
        public abstract Task RollbackActionQueueAsync();
        
        internal ActionQueue.ActionQueue<TIn, TOut> RunnerActionQueue => _actionQueue;
        internal IBusinessLogicData Repo => _repo;
    }
}