using Bayer.MyBayer.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Bayer.MyBayer.WebApi.Services.Definitions
{
    public interface IGrowerConsentService
    {
        Task<GrowerConsentFormModel> CreateGrowerConsent(GrowerConsentFormModel consentForm);
        Task<bool> ConfirmGrowerConsent(GrowerConsentConfirmationModel confirmation);
        Task<GrowerConsentFormModel> UpdateGrowerConsentStatus(GrowerConsentStatusModel consentStatus);
    }
}