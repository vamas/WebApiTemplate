using Bayer.MyBayer.WebApi.BusinessLogic.Action;
using Bayer.MyBayer.WebApi.BusinessLogic.ActionRunner;
using Bayer.MyBayer.WebApi.BusinessLogic.DataInterfaces;
using Bayer.MyBayer.WebApi.BusinessLogic.Model;
using Bayer.MyBayer.WebApi.Models;
using Bayer.MyBayer.WebApi.Services.Definitions;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Bayer.MyBayer.WebApi.Services
{
    public class GrowerConsentService : IGrowerConsentService
    {
        private readonly Runner<BusinessLogicEntity, BusinessLogicEntity> _runner;
        private readonly ConsentData _consentData;
        private readonly IConfirmationTokenService _tokenService;

        public IImmutableList<ValidationResult> Errors => _runner.Errors;       

        public GrowerConsentService(ConsentData consentData, IConfirmationTokenService tokenService)
        {
            _tokenService = tokenService;
            _runner = new Runner<BusinessLogicEntity, BusinessLogicEntity>(consentData);
            _consentData = consentData;
        }

        public async Task<GrowerConsentFormModel> CreateGrowerConsent(GrowerConsentFormModel consentForm)
        {
            var consent = await _consentData.GetConsent(consentForm.GrowerConsentCommonId);
            if (consent == null)
            {
                consentForm = AddConfirmationToken(consentForm);
                _runner.AddRunnerAction(
                    new SubmitGrowerConsentFormAction(_consentData), consentForm,
                    new DeleteGrowerConsentFormAction(_consentData), consentForm);
                if (consentForm.CropAcres != null)
                {
                    foreach (CropAcresModel crop in consentForm.CropAcres)
                    {
                        if (crop.GrowerConsentCommonId == null)
                            crop.GrowerConsentCommonId = consentForm.GrowerConsentCommonId;
                        _runner.AddRunnerAction(
                            new SubmitGrowerConsentCropAcres(_consentData), crop,
                            new DeleteGrowerConsentCropAcres(_consentData), crop);
                    }
                }
                var createdConsent = await _runner.RunActionQueueAsync();
                if ((!_runner.HasErrors) && (createdConsent.Count > 0))
                    return createdConsent[0] as GrowerConsentFormModel;
            }
            return null;
        }

        public async Task<bool> ConfirmGrowerConsent(GrowerConsentConfirmationModel confirmation)
        {
            if (_tokenService.ValidateConfirmationToken(confirmation.ConfirmationToken))
            {
                var confirmationToken = _tokenService.GetTokenFromHash(confirmation.ConfirmationToken);
                var confirmedConsent = new GrowerConsentStatusModel()
                {
                    GrowerFormCommonId = confirmationToken.CommonId,
                    GrowerConsent = true,
                    GrowerEmailAddress = confirmationToken.Email
                };
                return ((await UpdateGrowerConsentStatus(confirmedConsent)) != null) ? true : false;
            }
            return false;
        }

        public async Task<GrowerConsentFormModel> UpdateGrowerConsentStatus(GrowerConsentStatusModel consentStatus)
        {
            var consent = await _consentData.GetConsent(consentStatus.GrowerFormCommonId);
            if (consent != null)
            {
                _runner.AddRunnerAction(new UpdateGrowerConsentStatus(_consentData), consentStatus, null, null);
                var confirmed = await _runner.RunActionQueueAsync();
                if ((!_runner.HasErrors) && (confirmed.Count > 0))
                    return confirmed[0] as GrowerConsentFormModel;
            }
            return null;
        }

        private GrowerConsentFormModel AddConfirmationToken(GrowerConsentFormModel consentForm)
        {
            var token = _tokenService.GenerateConfirmationToken(consentForm.GrowerConsentCommonId, consentForm.Email);
            consentForm.ConfirmationToken = _tokenService.TokenHash(token);
            return consentForm;
        }
    }
}