using Bayer.MyBayer.WebApi.BusinessLogic.Action;
using Bayer.MyBayer.WebApi.BusinessLogic.Model;
using Bayer.MyBayer.WebApi.Test.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bayer.MyBayer.WebApi.Test.Helpers
{
    public class TestAction : BusinessActionBase
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
