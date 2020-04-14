using Bayer.MyBayer.WebApi.BusinessLogic.DataInterfaces;
using Bayer.MyBayer.WebApi.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bayer.MyBayer.CDIPData
{
    public class CdipData : ConsentData
    {
        private static Hashtable _consents = new Hashtable();
        private static Hashtable _cropAcres = new Hashtable();
        private static Hashtable _consentStatuses = new Hashtable();

        public CdipData()
        {
        }

        public async Task DeleteConsent(GrowerConsentFormModel consent)
        {
            await Task.Run(() =>
            {
                if (_consents.Contains(consent.GrowerConsentCommonId))
                {
                    _consents.Remove(consent.GrowerConsentCommonId);
                }
                return null;
            });
        }

        public async Task DeleteCropAcres(CropAcresModel cropAcre)
        {
            await Task.Run(() =>
            {
                if (_cropAcres.Contains(cropAcre.CropId))
                {
                    _cropAcres.Remove(cropAcre.CropId);
                }
                return null;
            });
        }

        public async Task<GrowerConsentFormModel> FindConsentByEmail(string email)
        {
            var task = await Task.Run(() =>
            {
                var consent = _consents.Values.OfType<GrowerConsentFormModel>()
                    .ToList()
                    .SingleOrDefault(x => x.Email == email);
                if (consent != null)
                    consent.CropAcres = _cropAcres.Values.OfType<CropAcresModel>().ToList()
                            .Where(x => x.GrowerConsentCommonId == consent.GrowerConsentCommonId).ToList();
                return consent;
            });
            return task;
        }

        public async Task<GrowerConsentFormModel> GetConsent(string id)
        {
            var task = await Task.Run(() =>
            {
                if (_consents.Contains(id))
                {
                    var consent = _consents[id] as GrowerConsentFormModel;
                    consent.CropAcres = _cropAcres.Values.OfType<CropAcresModel>().ToList()
                        .Where(x => x.GrowerConsentCommonId == id).ToList();
                    return consent;
                }
                return null;
            });
            return task;
        }

        public async Task<CropAcresModel> GetCropAcres(string id)
        {
            var task = await Task.Run(() =>
            {
                if (_cropAcres.Contains(id))
                {
                    return _cropAcres[id] as CropAcresModel;
                }
                return null;
            });
            return task;
        }

        public async Task<GrowerConsentFormModel> PostConsent(GrowerConsentFormModel consent)
        {
            var task = await Task.Run(() =>
            {
                if (!_consents.Contains(consent.GrowerConsentCommonId))
                {
                    _consents[consent.GrowerConsentCommonId] = consent;
                    return _consents[consent.GrowerConsentCommonId] as GrowerConsentFormModel;
                }
                return null;
            });
            return task;
        }

        public async Task<GrowerConsentFormModel> UpdateConsent(string id, GrowerConsentFormModel consent)
        {
            var task = await Task.Run(() =>
            {
                if (_consents.Contains(id))
                {
                    _consents[id] = consent;
                    return _consents[id] as GrowerConsentFormModel;
                }
                return null;
            });
            return task;
        }

        public async Task<CropAcresModel> PostCropAcres(CropAcresModel cropAcre)
        {
            var task = await Task.Run(() =>
            {
                if (!_cropAcres.Contains(cropAcre.CropId))
                {
                    _cropAcres[cropAcre.CropId] = cropAcre;
                    return _cropAcres[cropAcre.CropId] as CropAcresModel;
                }
                return null;
            });
            return task;
        }

        public async Task<GrowerConsentStatusModel> UpdateConsentStatus(GrowerConsentStatusModel status)
        {
            var task = await Task.Run(() =>
            {
                if (!_consentStatuses.Contains(status.GrowerFormCommonId))
                {
                    _consents[status.GrowerFormCommonId] = status;
                }
                else
                {
                    var currentStatus = _consents[status.GrowerFormCommonId] as GrowerConsentStatusModel;
                    currentStatus.GrowerConsent = status.GrowerConsent;
                    currentStatus.GrowerEmailAddress = status.GrowerEmailAddress;
                }
                return _consents[status.GrowerFormCommonId] as GrowerConsentStatusModel;
            });
            return task;
        }
    }
}
