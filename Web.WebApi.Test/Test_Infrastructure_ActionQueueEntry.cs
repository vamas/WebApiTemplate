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
    public class Test_Infrastructure_ActionQueueEntry
    {
        private IProductManagerData data;

        [SetUp]
        public void SetUp()
        {
            data = new TestRepo();
        }

        [Test]
        public void ActionQueueEntry_Test()
        {
            var model = new TestModel
            {
                id = 1,
                simulate_action_error = false,
                is_unrecoverable = false
            };
            var actionQueueEntry = new ActionQueueEntry<TestModel, TestModel>()
            {
                actionClass = new TestAction() as BusinessAction<TestModel, TestModel>,
                dataIn = model,
                execStatus = ActionExecStatus.Pending,
                rollbackActionClass = null,
                rollbackDataIn = null,
                rollbackExecStatus = ActionExecStatus.NoAction
            };
            Assert.AreEqual(new TestAction() as BusinessAction<TestModel, TestModel>, actionQueueEntry.actionClass);
            Assert.AreEqual(model, actionQueueEntry.dataIn);
            Assert.AreEqual(ActionExecStatus.Pending, actionQueueEntry.execStatus);
            Assert.Null(actionQueueEntry.rollbackActionClass);
            Assert.Null(actionQueueEntry.rollbackDataIn);
            Assert.AreEqual(ActionExecStatus.NoAction, actionQueueEntry.rollbackExecStatus);
        }
     }
}
