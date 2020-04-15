using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Infrastructure.ActionRunner.Interface;
using Web.Infrastructure.BusinessLogic.Model;

namespace Web.WebApi.Test.Helpers
{
    public abstract class TestActionBase :
       BusinessErrors, BusinessAction<BusinessLogicEntity, BusinessLogicEntity>
    {
        public abstract Task<BusinessLogicEntity> Action(BusinessLogicEntity dto);
    }
}
