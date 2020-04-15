using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using System.Threading.Tasks;
using Web.ProductManager.Interface;
using Web.ProductManager.Data;
using Web.Services;
using Web.Services.Interface;
using Web.Infrastructure.ActionRunner;
using Web.Infrastructure.BusinessLogic.Model;
using Web.WebApi.Test.Helpers;
using Web.Infrastructure.ActionRunner.Exceptions;

namespace Web.WebApi.Test
{
    [TestClass]
    public class TestActionRunner
    {
        private static IProductManagerData data;
        private static IProductManagementService service;

        [ClassInitialize]
        public static void TestInitialize(TestContext context)
        {
            data = new ProductManagerData();
            service = new ProductManagementService(data);
        }             

        [TestMethod]
        public async Task SingleSuccessfulAction()
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
            var result = await runner.RunActionQueueAsync();
            Assert.IsFalse(runner.HasErrors);
            Assert.AreEqual((result[0] as TestModel).id, 1);
        }

        [TestMethod]
        public async Task SingleFailingAction()
        {
            var model = new TestModel
            {
                id = 2,
                simulate_action_error = true,
                is_unrecoverable = false
            };
            Runner<BusinessLogicEntity, BusinessLogicEntity> runner = new
                Runner<BusinessLogicEntity, BusinessLogicEntity>(data);
            runner.AddRunnerAction(new TestAction(), model, null, null);
            var result = await runner.RunActionQueueAsync();
            Assert.IsTrue(runner.HasErrors);
            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task MultiSuccessfulAction()
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

        [TestMethod]
        public async Task MultiFailingAction()
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

        [TestMethod]
        [ExpectedException(typeof(RunnerException),
            "Unrecoverable action runner error encountered. Manual cleanup on CDIP backend is required")]
        public async Task MultiFailingActionUnrecoverable()
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
            var result = await runner.RunActionQueueAsync();
            Assert.IsTrue(runner.HasErrors);
            Assert.IsNull(result);
        }
    }
}
