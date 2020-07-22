using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.ProductManager.Interface;
using Web.ProductManager.Data;
using Web.Services;
using Web.Services.Interface;
using Web.Infrastructure.ActionRunner;
using Web.Infrastructure.BusinessLogic.Model;
using Web.WebApi.Test.Helpers;
using Web.Infrastructure.ActionRunner.Exceptions;
using NUnit.Framework;
using Web.Infrastructure.ActionQueue;
using System.Linq;
using Web.Infrastructure.ActionRunner.Interface;

namespace Web.WebApi.Test
{
    [TestFixture]
    public class Test_Infrastructure_ActionRunner
    {
        private IProductManagerData data;

        [SetUp]
        public void SetUp()
        {
            data = new TestRepo();
        }

        [Test]
        public void ActionRunner_RunnerBase_AddAction_Test()
        {
            var model = new TestModel
            {
                id = 1,
                simulate_action_error = false,
                is_unrecoverable = false
            };
            Runner<BusinessLogicEntity, BusinessLogicEntity> runner = new
                Runner<BusinessLogicEntity, BusinessLogicEntity>(data);
            runner.AddRunnerAction(new TestAction(), model, null, null);
            Assert.False(runner.ActionQueueIsEmpty);           
        }
        [Test]
        public void ActionRunner_RunnerBase_NoErrorsNoActionQueued_Test()
        {
            Runner<BusinessLogicEntity, BusinessLogicEntity> runner = new
                Runner<BusinessLogicEntity, BusinessLogicEntity>(data);
            Assert.Zero(runner.Errors.Count);
            Assert.False(runner.HasErrors);
        }
        [Test]
        public void ActionRunner_RunnerBase_NoErrorsActionQueued_Test()
        {
            var model = new TestModel
            {
                id = 1,
                simulate_action_error = false,
                is_unrecoverable = false
            };
            Runner<BusinessLogicEntity, BusinessLogicEntity> runner = new
                Runner<BusinessLogicEntity, BusinessLogicEntity>(data);
            runner.AddRunnerAction(new TestAction(), model, null, null);
            Assert.Zero(runner.Errors.Count);
            Assert.False(runner.HasErrors);
        }
        [Test]
        public async Task ActionRunner_RunnerBase_Errors_Test()
        {
            var model = new TestModel
            {
                id = 1,
                simulate_action_error = true,
                is_unrecoverable = false
            };
            Runner<BusinessLogicEntity, BusinessLogicEntity> runner = new
                Runner<BusinessLogicEntity, BusinessLogicEntity>(data);
            runner.AddRunnerAction(new TestAction(), model, null, null);
            var result = await runner.RunActionQueueAsync();
            Assert.NotZero(runner.Errors.Count);
            Assert.True(runner.HasErrors);
        }
        [Test]
        public void ActionRunner_RunnerBase_NoRollbackErrorsNoActionQueued_Test()
        {
            Runner<BusinessLogicEntity, BusinessLogicEntity> runner = new
                Runner<BusinessLogicEntity, BusinessLogicEntity>(data);
            Assert.Zero(runner.RollbackErrors.Count);
            Assert.False(runner.HasRollbackErrors);
        }
        [Test]
        public void ActionRunner_RunnerBase_NoRollbackErrorsActionQueued_Test()
        {
            var model = new TestModel
            {
                id = 1,
                simulate_action_error = false,
                is_unrecoverable = false
            };
            Runner<BusinessLogicEntity, BusinessLogicEntity> runner = new
                Runner<BusinessLogicEntity, BusinessLogicEntity>(data);
            runner.AddRunnerAction(new TestAction(), model, null, null);
            Assert.Zero(runner.RollbackErrors.Count);
            Assert.False(runner.HasRollbackErrors);
        }
        [Test]
        public async Task ActionRunner_RunnerBase_RollbackErrorsRecoverable_Test()
        {
            var model = new TestModel
            {
                id = 1,
                simulate_action_error = true,
                is_unrecoverable = true
            };
            Runner<BusinessLogicEntity, BusinessLogicEntity> runner = new
                Runner<BusinessLogicEntity, BusinessLogicEntity>(data);
            runner.AddRunnerAction(new TestAction(), model, null, null);
            var result = await runner.RunActionQueueAsync();
            Assert.NotZero(runner.Errors.Count);
            Assert.True(runner.HasErrors);
            Assert.Zero(runner.RollbackErrors.Count);
            Assert.False(runner.HasRollbackErrors);
        }
        [Test]
        public void ActionRunner_RunnerBase_RollbackErrorsNonRecoverable_Test()
        {
            var model = new TestModel
            {
                id = 4,
                simulate_action_error = false,
                is_unrecoverable = false
            };
            var model1 = new TestModel
            {
                id = 5,
                simulate_action_error = true,
                is_unrecoverable = true
            };
            Runner<BusinessLogicEntity, BusinessLogicEntity> runner = new
                Runner<BusinessLogicEntity, BusinessLogicEntity>(data);
            runner.AddRunnerAction(new TestAction(), model, null, null);
            runner.AddRunnerAction(new TestAction(), model, new TestRollbackAction(), model1);
            runner.AddRunnerAction(new TestAction(), model1, new TestRollbackAction(), model1);
            Assert.ThrowsAsync(typeof(RunnerException),
                async () => await runner.RunActionQueueAsync(),
                "Unrecoverable action runner error encountered. Manual cleanup is required");
        }
        [Test]
        public async Task ActionRunner_RunnerBase_RunActionQueueAsync_Test()
        {
            var model = new TestModel
            {
                id = 3,
                simulate_action_error = false,
                is_unrecoverable = false
            };
            Runner<BusinessLogicEntity, BusinessLogicEntity> runner = new
                Runner<BusinessLogicEntity, BusinessLogicEntity>(data);
            runner.AddRunnerAction(new TestAction(), model, null, null);
            runner.AddRunnerAction(new TestAction(), model, new TestRollbackAction(), model);
            runner.AddRunnerAction(new TestAction(), model, new TestRollbackAction(), model);
            var result = await runner.RunActionQueueAsync();
            Assert.IsFalse(runner.HasErrors);
            Assert.AreEqual((result[0] as TestModel).id, 3);
        }
        [Test]
        public async Task ActionRunner_RunnerBase_FailureRunActionQueueAsync_Test()
        {
            var model = new TestModel
            {
                id = 4,
                simulate_action_error = false,
                is_unrecoverable = false
            };
            var model1 = new TestModel
            {
                id = 5,
                simulate_action_error = true,
                is_unrecoverable = false
            };
            Runner<BusinessLogicEntity, BusinessLogicEntity> runner = new
                Runner<BusinessLogicEntity, BusinessLogicEntity>(data);
            runner.AddRunnerAction(new TestAction(), model, null, null);
            runner.AddRunnerAction(new TestAction(), model, new TestRollbackAction(), model);
            runner.AddRunnerAction(new TestAction(), model1, new TestRollbackAction(), model);
            var result = await runner.RunActionQueueAsync();
            Assert.IsTrue(runner.HasErrors);
            Assert.IsNull(result);
        }
    }
}
