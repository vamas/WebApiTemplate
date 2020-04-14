using Bayer.MyBayer.WebApi.BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Bayer.MyBayer.WebApi.BusinessLogic.Action
{
    public abstract class BusinessActionBase :
        BusinessErrors, BusinessAction<BusinessLogicEntity, BusinessLogicEntity>
    {
        public abstract Task<BusinessLogicEntity> Action(BusinessLogicEntity dto);
    }
}