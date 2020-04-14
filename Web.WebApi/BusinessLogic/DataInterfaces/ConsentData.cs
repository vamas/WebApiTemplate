using Bayer.MyBayer.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Bayer.MyBayer.WebApi.BusinessLogic.DataInterfaces
{
    public interface ConsentData
    {
        Task<GrowerConsentFormModel> FindConsentByEmail(string email);
        Task<GrowerConsentFormModel> GetConsent(string id);
        Task<CropAcresModel> GetCropAcres(string id);
        Task<GrowerConsentFormModel> PostConsent(GrowerConsentFormModel consent);
        Task<CropAcresModel> PostCropAcres(CropAcresModel cropAcre);
        Task DeleteConsent(GrowerConsentFormModel consent);
        Task DeleteCropAcres(CropAcresModel cropAcre);
        Task<GrowerConsentStatusModel> UpdateConsentStatus(GrowerConsentStatusModel status);
        Task<GrowerConsentFormModel> UpdateConsent(string id, GrowerConsentFormModel consent);
    }
}