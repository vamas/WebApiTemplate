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
    public class SubmitGrowerConsentCropAcres : BusinessActionBase
    {
        private readonly ConsentData _consentData;

        public SubmitGrowerConsentCropAcres(ConsentData consentData)
        {
            _consentData = consentData;
        }

        public override async Task<BusinessLogicEntity> Action(BusinessLogicEntity dto)
        {
            CropAcresModel entity = dto as CropAcresModel;
            if ((await _consentData.GetCropAcres(entity.CropId)) != null)
            {
                AddError(string.Format("CropAcre with Id={0} already exists", entity.CropId));
                return null;
            }
            return await _consentData.PostCropAcres(entity);
        }
    }
}