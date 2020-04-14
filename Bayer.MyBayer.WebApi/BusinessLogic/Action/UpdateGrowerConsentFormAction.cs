using Bayer.MyBayer.WebApi.BusinessLogic.DataInterfaces;
using Bayer.MyBayer.WebApi.BusinessLogic.Model;
using Bayer.MyBayer.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Bayer.MyBayer.WebApi.BusinessLogic.Action
{
    public class UpdateGrowerConsentFormAction : BusinessActionBase
    {
        private readonly ConsentData _consentData;

        public UpdateGrowerConsentFormAction(ConsentData consentData)
        {
            _consentData = consentData;
        }

        public override async Task<BusinessLogicEntity> Action(BusinessLogicEntity dto)
        {
            GrowerConsentFormModel entity = dto as GrowerConsentFormModel;
            if ((await _consentData.GetConsent(entity.GrowerConsentCommonId)) == null)
            {
                AddError(string.Format("Consent with Id={0} doesn't exist", entity.GrowerConsentCommonId));
                return null;
            }
            await _consentData.UpdateConsent(entity.GrowerConsentCommonId, entity);
            return dto;
        }
    }
}