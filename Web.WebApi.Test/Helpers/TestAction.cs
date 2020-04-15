using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Infrastructure.BusinessLogic.Model;

namespace Web.WebApi.Test.Helpers
{
    public class TestAction : TestActionBase
    {
        public override async Task<BusinessLogicEntity> Action(BusinessLogicEntity dto)
        {
            var task = await Task.Run(() =>
            {
                TestModel entity = dto as TestModel;
                if (entity.simulate_action_error)
                    AddError("Action error encountered");
                return entity;
            });
            return task;
        }
    }
}
