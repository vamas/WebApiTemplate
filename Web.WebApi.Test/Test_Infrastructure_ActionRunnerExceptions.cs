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
    public class Test_Infrastructure_ActionRunnerExceptions
    {
        private IProductManagerData data;

        [SetUp]
        public void SetUp()
        {
            data = new TestRepo();
        }

        [Test]
        public void ActionQueueEntry_RunnerException1_Test()
        {
            Assert.Throws(typeof(RunnerException),
                delegate { throw new RunnerException(); },
                "Action runner error encountered");
        }

        [Test]
        public void ActionQueueEntry_RunnerException2_Test()
        {
            Assert.Throws(typeof(RunnerException),
                delegate { throw new RunnerException("Test message"); },
                "Test message");
        }

        [Test]
        public void ActionQueueEntry_RunnerException3_Test()
        {
            Assert.Throws(typeof(RunnerException),
                delegate { throw new RunnerException("Test message 1", new Exception("InnerException")); },
                "Test message 1");
        }
    }
}
