using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Web.Infrastructure.ActionRunner.Interface;
using Web.Infrastructure.BusinessLogic.Model;

namespace Web.ProductManager.Action
{
    public abstract class ProductManagerActionBase :
        BusinessErrors, BusinessAction<BusinessLogicEntity, BusinessLogicEntity>
    {
        public abstract Task<BusinessLogicEntity> Action(BusinessLogicEntity dto);
    }
}