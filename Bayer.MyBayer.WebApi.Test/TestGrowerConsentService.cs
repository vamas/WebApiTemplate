using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bayer.MyBayer.WebApi.Models;
using System.Collections.Generic;
using Bayer.MyBayer.WebApi.Controllers;
using Bayer.MyBayer.WebApi.Services.Definitions;
using Bayer.MyBayer.WebApi.Services;
using Bayer.MyBayer.WebApi.DAL;
using System.Web.Http;
using System.Web.Http.Results;
using Bayer.MyBayer.WebApi.BusinessLogic.DataInterfaces;
using Bayer.MyBayer.CDIPData;
using System.Threading.Tasks;

namespace Bayer.MyBayer.WebApi.Test
{
    [TestClass]
    public class TestGrowerConsentService
    {
        private static IEncodingService encryptionService;        
        private static IConfirmationTokenService confirmationTokenService;
        private ConsentData consentData;
        private IGrowerConsentService service;

        [ClassInitialize]
        public static void TestInitialize(TestContext context)
        {
            encryptionService = new EncodingServiceSHA("");
            confirmationTokenService = new ConfirmationTokenService(encryptionService, 4, 1);            
        }

        [TestMethod]
        public async Task CreateConsent()
        {
            consentData = new CdipData();
            service = new GrowerConsentService(consentData, confirmationTokenService);
            var id = Guid.NewGuid().ToString();
            var consent = new GrowerConsentFormModel
            {
                GrowerConsentCommonId = id,
                ContactName = "TestConsent",
                Email = "bla@com.dfd",
            };
            await service.CreateGrowerConsent(consent);
            var insertedConsent = await consentData.GetConsent(id);
            Assert.AreEqual(consent.ContactName, insertedConsent.ContactName);
            Assert.AreEqual(consent.Email, insertedConsent.Email);
        }

        [TestMethod]
        public async Task CreateConsentCropAcres()
        {
            consentData = new CdipData();
            service = new GrowerConsentService(consentData, confirmationTokenService);
            var consent = new GrowerConsentFormModel
            {
                GrowerConsentCommonId = Guid.NewGuid().ToString(),
                ContactName = "TestConsent1",
                Email = "bla@ss.dfd",
                CropAcres = new List<CropAcresModel>()
                {
                    new CropAcresModel
                    {
                        CropId = Guid.NewGuid().ToString(),
                        CropName = "Rubbish",
                        CropAcres = 100500
                    },
                    new CropAcresModel
                    {
                        CropId = Guid.NewGuid().ToString(),
                        CropName = "Garbage",
                        CropAcres = 1050
                    },
                }
            };
            await service.CreateGrowerConsent(consent);
            var insertedConsent = await consentData.GetConsent(consent.GrowerConsentCommonId);
            Assert.AreEqual(consent.ContactName, insertedConsent.ContactName);
            foreach(var crop in consent.CropAcres)
            {
                var insertedCrop = await consentData.GetCropAcres(crop.CropId);
                Assert.AreEqual(insertedCrop.CropName, crop.CropName);
                Assert.AreEqual(insertedCrop.CropAcres, crop.CropAcres);
            }
        }
    }
}
