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
    public class SubmitGrowerConsentFormAction : BusinessActionBase
    {
        private readonly ConsentData _consentData;

        public SubmitGrowerConsentFormAction(ConsentData consentData)
        {
            _consentData = consentData;
        }

        public override async Task<BusinessLogicEntity> Action(BusinessLogicEntity dto)
        {
            GrowerConsentFormModel entity = dto as GrowerConsentFormModel;
            if ((await _consentData.FindConsentByEmail(entity.Email)) != null)
            {
                AddError(string.Format("Consent with email={0} already exists", entity.Email));
                return null;
            }
            return await _consentData.PostConsent(entity);
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