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

namespace Web.WebApi.Test
{
    [TestFixture]
    public class Test_Infrastructure_ActionQueue
    {
        private IProductManagerData data;

        [SetUp]
        public void SetUp()
        {
            data = new TestRepo();
        }

        [Test]
        public void ActionQueueAddEntry_Test()
        {
            var actionQueue = new ActionQueue<BusinessLogicEntity, BusinessLogicEntity>();
            actionQueue.Add(new ActionQueueEntry<BusinessLogicEntity, BusinessLogicEntity>());
            Assert.AreEqual(1, actionQueue.Count);
        }
        [Test]
        public void ActionQueueAddMultipleEntries_Test()
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
        public void ActionQueueRemoveMultipleEntries_Test()
        {
            var actionQueue = new ActionQueue<BusinessLogicEntity, BusinessLogicEntity>();
            var entry = new ActionQueueEntry<BusinessLogicEntity, BusinessLogicEntity>();
            actionQueue.Add(entry);
            actionQueue.Remove(entry);
            Assert.AreEqual(0, actionQueue.Count);
        }
        [Test]
        public void ActionQueueValidateEntryIsIn_Test()
        {
            var actionQueue = new ActionQueue<BusinessLogicEntity, BusinessLogicEntity>();
            var entry = new ActionQueueEntry<BusinessLogicEntity, BusinessLogicEntity>
            {
                actionClass = new TestAction(),
                dataIn = new TestModel
                {
                    id = 100500,
                    simulate_action_error = false,
                    is_unrecoverable = false
                },
                execStatus = ActionExecStatus.Pending
            };
            actionQueue.Add(entry);
            Assert.IsTrue(actionQueue.Contains(entry));
        }
        [Test]
        public void ActionQueueValidateEntryIsNotIn_Test()
        {
            var actionQueue = new ActionQueue<BusinessLogicEntity, BusinessLogicEntity>();
            var entry = new ActionQueueEntry<BusinessLogicEntity, BusinessLogicEntity>
            {
                actionClass = new TestAction(),
                dataIn = new TestModel
                {
                    id = 100500,
                    simulate_action_error = false,
                    is_unrecoverable = false
                },
                execStatus = ActionExecStatus.Pending
            };
            actionQueue.Add(new ActionQueueEntry<BusinessLogicEntity, BusinessLogicEntity>
            {
                actionClass = new TestAction(),
                dataIn = new TestModel
                {
                    id = 100501,
                    simulate_action_error = false,
                    is_unrecoverable = false
                },
                execStatus = ActionExecStatus.Pending
            });
            Assert.IsFalse(actionQueue.Contains(entry));
        }
        [Test]
        public void ActionQueuePurge_Test()
        {
            var actionQueue = new ActionQueue<BusinessLogicEntity, BusinessLogicEntity>();
            actionQueue.Add(new ActionQueueEntry<BusinessLogicEntity, BusinessLogicEntity>());
            actionQueue.Add(new ActionQueueEntry<BusinessLogicEntity, BusinessLogicEntity>());
            actionQueue.Add(new ActionQueueEntry<BusinessLogicEntity, BusinessLogicEntity>());
            actionQueue.Add(new ActionQueueEntry<BusinessLogicEntity, BusinessLogicEntity>());
            actionQueue.Add(new ActionQueueEntry<BusinessLogicEntity, BusinessLogicEntity>());
            actionQueue.Clear();
            Assert.AreEqual(0, actionQueue.Count);
        }
        [Test]
        public void ActionQueueCopyTo_Test()
        {
            var actionQueue = new ActionQueue<BusinessLogicEntity, BusinessLogicEntity>();
            actionQueue.Add(new ActionQueueEntry<BusinessLogicEntity, BusinessLogicEntity>());
            actionQueue.Add(new ActionQueueEntry<BusinessLogicEntity, BusinessLogicEntity>());
            actionQueue.Add(new ActionQueueEntry<BusinessLogicEntity, BusinessLogicEntity>());
            actionQueue.Add(new ActionQueueEntry<BusinessLogicEntity, BusinessLogicEntity>());
            actionQueue.Add(new ActionQueueEntry<BusinessLogicEntity, BusinessLogicEntity>());
            ActionQueueEntry<BusinessLogicEntity, BusinessLogicEntity>[] actionQueueArray = new
                ActionQueueEntry<BusinessLogicEntity, BusinessLogicEntity>[] { null, null, null, null, null, null, null};
            actionQueue.CopyTo(actionQueueArray, 1);
            Assert.AreEqual(5, actionQueueArray
                .OfType<ActionQueueEntry<BusinessLogicEntity, BusinessLogicEntity>>()
                .ToList()
                .Where(c => c != null)
                .Count());
        }
        [Test]
        public void ActionQueueIndexOf_Test()
        {
            var actionQueue = new ActionQueue<BusinessLogicEntity, BusinessLogicEntity>();
            actionQueue.Add(new ActionQueueEntry<BusinessLogicEntity, BusinessLogicEntity>());
            var entry = new ActionQueueEntry<BusinessLogicEntity, BusinessLogicEntity>
            {
                actionClass = new TestAction(),
                dataIn = new TestModel
                {
                    id = 100501,
                    simulate_action_error = false,
                    is_unrecoverable = false
                },
                execStatus = ActionExecStatus.Pending
            };
            actionQueue.Add(entry);
            Assert.AreEqual(1, actionQueue.IndexOf(entry));
        }
        [Test]
        public void ActionQueueRemoveAt_Test()
        {
            var actionQueue = new ActionQueue<BusinessLogicEntity, BusinessLogicEntity>();
            actionQueue.Add(new ActionQueueEntry<BusinessLogicEntity, BusinessLogicEntity>());
            var entry = new ActionQueueEntry<BusinessLogicEntity, BusinessLogicEntity>
            {
                actionClass = new TestAction(),
                dataIn = new TestModel
                {
                    id = 100501,
                    simulate_action_error = false,
                    is_unrecoverable = false
                },
                execStatus = ActionExecStatus.Pending
            };
            actionQueue.Add(entry);
            actionQueue.RemoveAt(1);
            Assert.AreEqual(1, actionQueue.Count());
            Assert.AreEqual(0, actionQueue
                .Where(c => c.Equals(entry))
                .Count());
        }
        [Test]
        public void ActionQueueSetter_Test()
        {
            var actionQueue = new ActionQueue<BusinessLogicEntity, BusinessLogicEntity>();
            actionQueue.Add(new ActionQueueEntry<BusinessLogicEntity, BusinessLogicEntity>());
            actionQueue.Add(new ActionQueueEntry<BusinessLogicEntity, BusinessLogicEntity>());
            var entry = new ActionQueueEntry<BusinessLogicEntity, BusinessLogicEntity>
            {
                actionClass = new TestAction(),
                dataIn = new TestModel
                {
                    id = 100501,
                    simulate_action_error = false,
                    is_unrecoverable = false
                },
                execStatus = ActionExecStatus.Pending
            };
            actionQueue[1] = entry;
            Assert.AreEqual(2, actionQueue.Count());
            Assert.AreEqual(1, actionQueue
                .Where(c => c.Equals(entry))
                .Count());
        }
        [Test]
        public void ActionQueueGetter_Test()
        {
            var actionQueue = new ActionQueue<BusinessLogicEntity, BusinessLogicEntity>();
            actionQueue.Add(new ActionQueueEntry<BusinessLogicEntity, BusinessLogicEntity>());
            actionQueue.Add(new ActionQueueEntry<BusinessLogicEntity, BusinessLogicEntity>());
            var entry = new ActionQueueEntry<BusinessLogicEntity, BusinessLogicEntity>
            {
                actionClass = new TestAction(),
                dataIn = new TestModel
                {
                    id = 100501,
                    simulate_action_error = false,
                    is_unrecoverable = false
                },
                execStatus = ActionExecStatus.Pending
            };
            actionQueue[1] = entry;
            Assert.AreEqual(entry, actionQueue[1]);
        }
        [Test]
        public void ActionQueueInsert_Test()
        {
            var actionQueue = new ActionQueue<BusinessLogicEntity, BusinessLogicEntity>();
            Assert.Throws(typeof(NotImplementedException),
                delegate { actionQueue.Insert(0, new ActionQueueEntry<BusinessLogicEntity, BusinessLogicEntity>()); });
        }
        [Test]
        public void ActionQueueIsReadonly_Test()
        {
            var actionQueue = new ActionQueue<BusinessLogicEntity, BusinessLogicEntity>();
            Assert.IsFalse(actionQueue.IsReadOnly);
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
