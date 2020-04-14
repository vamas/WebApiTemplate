using Bayer.MyBayer.WebApi.BusinessLogic.DataInterfaces;
using Bayer.MyBayer.WebApi.BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Bayer.MyBayer.WebApi.BusinessLogic.ActionRunner
{
    public abstract class RunnerBase<TIn, TOut>
        where TIn: BusinessLogicEntity
        where TOut: BusinessLogicEntity
    {
        private IList<RunnerActionEntry<TIn, TOut>> _actionQueue;
        private readonly ConsentData _repo;

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
                    foreach (var rollbackRunnerAction in _actionQueue.Where(x => x.rollbackExecStatus == ActionExecStatus.Queued))
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

        public RunnerBase(ConsentData repo)
        {
            _repo = repo;
            _actionQueue = new List<RunnerActionEntry<TIn, TOut>>();
        }

        public void AddRunnerAction(
            BusinessAction<TIn, TOut> actionClass, TIn dataIn,
            BusinessAction<TIn, TOut> rollbackActionClass, TIn rollbackDataIn
            )
        {
            _actionQueue.Add(new RunnerActionEntry<TIn, TOut>
            {
                actionClass = actionClass,
                dataIn = dataIn,
                execStatus = ActionExecStatus.Queued,
                rollbackActionClass = rollbackActionClass,
                rollbackDataIn = rollbackDataIn,
                rollbackExecStatus = ActionExecStatus.NoAction
            });
        }
        public abstract Task<IList<TOut>> RunActionQueueAsync();
        public abstract Task RollbackActionQueueAsync();

        internal IList<RunnerActionEntry<TIn, TOut>> ActionQueue => _actionQueue;
        internal ConsentData Repo => _repo;
    }


    public class RunnerActionEntry<TIn, TOut>
        where TIn: BusinessLogicEntity
        where TOut: BusinessLogicEntity
    {
        public BusinessAction<TIn, TOut> actionClass { get; set; }
        public TIn dataIn { get; set; }
        public ActionExecStatus execStatus { get; set; }
        public BusinessAction<TIn, TOut> rollbackActionClass { get; set; }
        public TIn rollbackDataIn { get; set; }
        public ActionExecStatus rollbackExecStatus { get; set; }
    }

    public enum ActionExecStatus
    {
        NoAction=0,
        Queued=1,
        Success=2,
        Error=3,
        Recovered=4
    }
}