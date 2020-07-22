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
        public void AddActionQueueEntry_Test()
        {
            var actionQueue = new ActionQueue<BusinessLogicEntity, BusinessLogicEntity>();
            actionQueue.Add(new ActionQueueEntry<BusinessLogicEntity, BusinessLogicEntity>());
            Assert.AreEqual(1, actionQueue.Count);
        }
        [Test]
        public void AddMultipleActionsQueueEntry_Test()
        {
            var actionQueue = new ActionQueue<BusinessLogicEntity, BusinessLogicEntity>();
            actionQueue.Add(new ActionQueueEntry<BusinessLogicEntity, BusinessLogicEntity>());
            actionQueue.Add(new ActionQueueEntry<BusinessLogicEntity, BusinessLogicEntity>());
            actionQueue.Add(new ActionQueueEntry<BusinessLogicEntity, BusinessLogicEntity>());
            actionQueue.Add(new ActionQueueEntry<BusinessLogicEntity, BusinessLogicEntity>());
            actionQueue.Add(new ActionQueueEntry<BusinessLogicEntity, BusinessLogicEntity>());
            Assert.AreEqual(5, actionQueue.Count);
        }
        [Test]
        public void RemoveMultipleActionsQueueEntry_Test()
        {
            var actionQueue = new ActionQueue<BusinessLogicEntity, BusinessLogicEntity>();
            var entry = new ActionQueueEntry<BusinessLogicEntity, BusinessLogicEntity>();
            actionQueue.Add(entry);
            actionQueue.Remove(entry);
            Assert.AreEqual(0, actionQueue.Count);
        }


        [Test]
        public void AddRunnerAction_Test()
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
            Assert.IsFalse(runner.ActionQueueIsEmpty);
        }

        [Test]
        public void ActionQueueEmpty_Test()
        {            
            Runner<BusinessLogicEntity, BusinessLogicEntity> runner = new
                Runner<BusinessLogicEntity, BusinessLogicEntity>(data);
            Assert.IsTrue(runner.ActionQueueIsEmpty);
        }
    }
}
