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
    public class UpdateGrowerConsentStatus : BusinessActionBase
    {
        private readonly ConsentData _consentData;

        public UpdateGrowerConsentStatus(ConsentData consentData)
        {
            _consentData = consentData;
        }

        public override async Task<BusinessLogicEntity> Action(BusinessLogicEntity dto)
        {
            GrowerConsentStatusModel entity = dto as GrowerConsentStatusModel;
            var consent = await _consentData.GetConsent(entity.GrowerFormCommonId);
            if (consent == null)
            {
                AddError(string.Format("Consent with Id={0} doesn't exist", entity.GrowerFormCommonId));
                return null;
            }

            return await _consentData.UpdateConsentStatus(entity);
        }
    }

    //public class SubmitGrowerConsentFormAction :
    //    BusinessErrors, BusinessAction<GrowerConsentFormModel, GrowerConsentFormModel>
    //{
    //    private readonly ConsentData _consentData;

    //    public SubmitGrowerConsentFormAction(ConsentData consentData)
    //    {
    //        _consentData = consentData;
    //    }

    //    public async Task<GrowerConsentFormModel> Action(GrowerConsentFormModel dto)
    //    {
    //        if ((await _consentData.FindConsentByEmail(dto.Email)) != null)
    //        {
    //            AddError(string.Format("Consent with email={0} already exists", dto.Email));
    //            return null;
    //        }
    //        return await _consentData.PostConsent(dto);
    //    }
    //}
}