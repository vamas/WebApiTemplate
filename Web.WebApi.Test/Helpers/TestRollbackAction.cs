using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Infrastructure.BusinessLogic.Model;

namespace Web.WebApi.Test.Helpers
{
    public class TestRollbackAction : TestActionBase
    {
        public override async Task<BusinessLogicEntity> Action(BusinessLogicEntity dto)
        {
            var task = await Task.Run(() =>
            {
                TestModel entity = dto as TestModel;
                if (entity.is_unrecoverable)
                    AddError("Action error encountered");
                return entity;
            });
            return task;
        }
    }
}
