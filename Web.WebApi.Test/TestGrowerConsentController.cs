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

namespace Web.WebApi.Test
{
    [TestClass]
    public class TestGrowerConsentController
    {
    //    IEncodingService encryptionService;
    //    IConfirmationTokenService tokenService;
    //    IGrowerService growerService;
    //    IDbContext dbContext;
    //    public TestGrowerConsentController()
    //    {
    //        encryptionService = new EncodingServiceSHA("");
    //        dbContext = new GrowerDbContext(
    //            "Data Source=WCAC001569\\BAYER; Initial Catalog=BCS_MDM_Stage;Integrated Security=True;MultipleActiveResultSets=True;App=EntityFramework");
    //        tokenService = new ConfirmationTokenService(dbContext, encryptionService, 4, 1);
    //        growerService = new GrowerService(dbContext, tokenService);                
    //    }
    //    [TestMethod]
    //    public void TestPost_CreateNewGrowerConsentEntry()
    //    {
    //        var testConsents = GetTestConsents();
    //        var controller = new GrowerConsentFormController(growerService);
    //        IHttpActionResult actionResult = controller.Post(testConsents[0]);
    //        var createdResult = actionResult as OkNegotiatedContentResult<GrowerConsentFormModel>;
    //        var contentResult = createdResult.Content as GrowerConsentFormModel;
    //        Assert.IsNotNull(createdResult);
    //        Assert.IsNotNull(contentResult.GrowerConsentCommonId);
    //        Assert.IsTrue(contentResult.GrowerConsentCommonId.Length > 0);
    //        Assert.AreEqual("John Doe Jr", contentResult.ContactName);
    //        Assert.AreEqual("John Doe's Jr Farm", contentResult.FarmName);
    //        Assert.AreEqual("John Doe Sr", contentResult.ChequePayee);
    //        Assert.AreEqual("10500 Bluebulb Rd", contentResult.Address);
    //        Assert.AreEqual("Amber", contentResult.City);
    //        Assert.AreEqual("QC", contentResult.Province);
    //        Assert.AreEqual("5N7Q4E", contentResult.PostalCode);
    //        Assert.AreEqual("3093456789", contentResult.PhoneNumber);
    //        Assert.AreEqual("Phone", contentResult.PhoneType);
    //        Assert.AreEqual("john.doe.jr@badmail.com", contentResult.Email);
    //        Assert.AreEqual("John Doe's Farm", contentResult.FarmPartnershipName);
    //        Assert.AreEqual("John Doe Sr", contentResult.PartnerContactName);
    //        Assert.AreEqual("101501", contentResult.TotalFarmAcres);
    //        Assert.AreEqual(0, contentResult.CropAcres.Count);
    //    }
    //    [TestMethod]
    //    public void TestPost_CreateFailingGrowerConsentEntry()
    //    {
    //        var testConsents = GetTestConsents();
    //        var controller = new GrowerConsentFormController(growerService);
    //        IHttpActionResult actionResult = controller.Post(testConsents[3]);
    //        var createdResult = actionResult as OkNegotiatedContentResult<GrowerConsentFormModel>;
    //        var contentResult = createdResult.Content as GrowerConsentFormModel;
    //        Assert.IsNotNull(createdResult);
    //        Assert.IsNotNull(contentResult.GrowerConsentCommonId);
    //        Assert.IsTrue(contentResult.GrowerConsentCommonId.Length > 0);
    //    }
    //    [TestMethod]
    //    public void TestPost_CreateNewGrowerConsentEntryWithConfirmation()
    //    {
    //        var testConsents = GetTestConsents();
    //        var controller = new GrowerConsentFormController(growerService);
    //        IHttpActionResult actionResult = controller.Post(testConsents[1]);
    //        var createdResult = actionResult as OkNegotiatedContentResult<GrowerConsentFormModel>;
    //        var contentResult = createdResult.Content as GrowerConsentFormModel;
    //        var confirmtaionToken = contentResult.ConfirmationToken;
    //        Assert.IsNotNull(createdResult);
    //        Assert.IsNotNull(contentResult.GrowerConsentCommonId);
    //        Assert.AreEqual("John Doe's Jr Farm1", contentResult.FarmName);
    //        var controllerConf = new GrowerConsentConfirmationController(growerService);
    //        IHttpActionResult actionResultConf = controllerConf.Post(new GrowerConsentConfirmationModel()
    //        {
    //            ConfirmationToken = confirmtaionToken
    //        });
    //        var createdResultConf = actionResultConf as OkNegotiatedContentResult<bool>;
    //        Assert.IsTrue(createdResultConf.Content);
    //    }
    //    [TestMethod]
    //    public void TestPost_CreateNewGrowerConsentEntryWithExpiredConfirmation()
    //    {
    //        var tokenServiceLocal = new ConfirmationTokenService(dbContext, encryptionService, -48, 1);
    //        var growerServiceLocal = new GrowerService(dbContext, tokenServiceLocal);
    //        var testConsents = GetTestConsents();
    //        var controller = new GrowerConsentFormController(growerServiceLocal);
    //        IHttpActionResult actionResult = controller.Post(testConsents[2]);
    //        var createdResult = actionResult as OkNegotiatedContentResult<GrowerConsentFormModel>;
    //        var contentResult = createdResult.Content as GrowerConsentFormModel;
    //        var confirmtaionToken = contentResult.ConfirmationToken;
    //        Assert.IsNotNull(createdResult);
    //        Assert.IsNotNull(contentResult.GrowerConsentCommonId);
    //        Assert.AreEqual("John Doe's Jr Farm2", contentResult.FarmName);
    //        var controllerConf = new GrowerConsentConfirmationController(growerServiceLocal);
    //        IHttpActionResult actionResultConf = controllerConf.Post(new GrowerConsentConfirmationModel()
    //        {
    //            ConfirmationToken = confirmtaionToken
    //        });
    //        var createdResultConf = actionResultConf as BadRequestErrorMessageResult;
    //        Assert.AreEqual(createdResultConf.Message, "Confirmation token is expired");
    //    }
    //    [TestMethod]
    //    public void TestPost_PostWrongRandomConfirmation()
    //    {
    //        var controllerConf = new GrowerConsentConfirmationController(growerService);
    //        IHttpActionResult actionResultConf = controllerConf.Post(new GrowerConsentConfirmationModel()
    //        {
    //            ConfirmationToken = "HihLgq1j9DsXmr0zBhayTjhVUc6W8pq5Zpmnx01MNj59dRF24x3c36aaRSSJosJcY"
    //        });
    //        var createdResultConf = actionResultConf as BadRequestErrorMessageResult;
    //        Assert.AreEqual(createdResultConf.Message, "Invalid confirmation token provided");
    //    }
    //    [TestMethod]
    //    public void TestPost_CreateNewGrowerConsentEntryWithConfirmationSimpleEncoding()
    //    {
    //        var encryptionServiceLocal = new EncodingServiceSimple();
    //        var tokenServiceLocal = new ConfirmationTokenService(dbContext, encryptionServiceLocal, 48, 1);
    //        var growerServiceLocal = new GrowerService(dbContext, tokenServiceLocal);
    //        var testConsents = GetTestConsents();
    //        var controller = new GrowerConsentFormController(growerServiceLocal);
    //        IHttpActionResult actionResult = controller.Post(testConsents[4]);
    //        var createdResult = actionResult as OkNegotiatedContentResult<GrowerConsentFormModel>;
    //        var contentResult = createdResult.Content as GrowerConsentFormModel;
    //        var confirmtaionToken = contentResult.ConfirmationToken;
    //        Assert.IsNotNull(createdResult);
    //        Assert.IsNotNull(contentResult.GrowerConsentCommonId);
    //        Assert.AreEqual("John Doe's Jr JDK", contentResult.FarmName);
    //        var controllerConf = new GrowerConsentConfirmationController(growerServiceLocal);
    //        IHttpActionResult actionResultConf = controllerConf.Post(new GrowerConsentConfirmationModel()
    //        {
    //            ConfirmationToken = confirmtaionToken
    //        });
    //        var createdResultConf = actionResultConf as OkNegotiatedContentResult<bool>;
    //        Assert.IsTrue(createdResultConf.Content);
    //    }
    //    [TestMethod]
    //    public void TestPost_ResendNotConfirmedConsent()
    //    {
    //        var testConsents = GetTestConsents();
    //        var controller = new GrowerConsentFormController(growerService);
    //        IHttpActionResult actionResult = controller.Post(testConsents[5]);
    //        var createdResult = actionResult as OkNegotiatedContentResult<GrowerConsentFormModel>;
    //        var contentResult1 = createdResult.Content as GrowerConsentFormModel;
    //        var confirmtaionToken1 = contentResult1.ConfirmationToken;
    //        Assert.IsNotNull(createdResult);
    //        Assert.IsNotNull(contentResult1.GrowerConsentCommonId);
    //        Assert.AreEqual("John Doe's Jr JDK1", contentResult1.FarmName);

    //        testConsents = GetTestConsents();
    //        controller = new GrowerConsentFormController(growerService);
    //        actionResult = controller.Post(testConsents[6]);
    //        createdResult = actionResult as OkNegotiatedContentResult<GrowerConsentFormModel>;
    //        var contentResult2 = createdResult.Content as GrowerConsentFormModel;
    //        var confirmtaionToken2 = contentResult2.ConfirmationToken;
    //        Assert.IsNotNull(createdResult);
    //        Assert.IsNotNull(contentResult2.GrowerConsentCommonId);
    //        Assert.AreEqual("John Doe's Jr JDK2", contentResult2.FarmName);
    //        Assert.AreEqual(contentResult1.GrowerConsentCommonId, contentResult2.GrowerConsentCommonId);
    //    }
    //    [TestMethod]
    //    public void TestPost_ResendConfirmedConsent()
    //    {
    //        var testConsents = GetTestConsents();
    //        var controller = new GrowerConsentFormController(growerService);
    //        IHttpActionResult actionResult = controller.Post(testConsents[7]);
    //        var createdResult = actionResult as OkNegotiatedContentResult<GrowerConsentFormModel>;
    //        var contentResult1 = createdResult.Content as GrowerConsentFormModel;
    //        var confirmtaionToken1 = contentResult1.ConfirmationToken;
    //        Assert.IsNotNull(createdResult);
    //        Assert.IsNotNull(contentResult1.GrowerConsentCommonId);
    //        Assert.AreEqual("John Doe's Jr JDK3", contentResult1.FarmName);
    //        var controllerConf = new GrowerConsentConfirmationController(growerService);
    //        IHttpActionResult actionResultConf = controllerConf.Post(new GrowerConsentConfirmationModel()
    //        {
    //            ConfirmationToken = confirmtaionToken1
    //        });
    //        var createdResultConf = actionResultConf as OkNegotiatedContentResult<bool>;
    //        Assert.IsTrue(createdResultConf.Content);

    //        testConsents = GetTestConsents();
    //        controller = new GrowerConsentFormController(growerService);
    //        actionResult = controller.Post(testConsents[8]);
    //        createdResult = actionResult as OkNegotiatedContentResult<GrowerConsentFormModel>;
    //        Assert.IsNull(createdResult);
    //        //Assert.AreEqual("The email provided already associated with existing grower consent",
    //        //   actionResult.);

    //        //var contentResult2 = createdResult.Content as GrowerConsentFormModel;

    //        //var confirmtaionToken2 = contentResult2.ConfirmationToken;
    //        //Assert.IsNotNull(createdResult);
    //        //Assert.IsNotNull(contentResult2.GrowerConsentCommonId);
    //        //Assert.AreEqual("John Doe's Jr JDK4", contentResult2.FarmName);
    //        //Assert.AreNotEqual(contentResult1.GrowerConsentCommonId, contentResult2.GrowerConsentCommonId);
    //    }
    //    [TestCleanup]
    //    public void Cleanup()
    //    {
    //        dbContext.Database.ExecuteSqlCommand(
    //            "Delete from stagein.web_grower_consent where org_name like 'John Doe''s Jr Farm%'");
    //    }
    //    private List<GrowerConsentFormModel> GetTestConsents()
    //    {
    //        var testConsents = new List<GrowerConsentFormModel>();
    //        //#0
    //        testConsents.Add(new GrowerConsentFormModel()
    //        {
    //            ContactName = "John Doe Jr",
    //            FarmName = "John Doe's Jr Farm",
    //            ChequePayee = "John Doe Sr",
    //            Address = "10500 Bluebulb Rd",
    //            City = "Amber",
    //            Province = "QC",
    //            PostalCode = "5N7Q4E",
    //            PhoneNumber = "3093456789",
    //            PhoneType = "Phone",
    //            Email = "john.doe.jr@badmail.com",
    //            FarmPartnershipName = "John Doe's Farm",
    //            PartnerContactName = "John Doe Sr",
    //            TotalFarmAcres = "101501",
    //            CropAcres = new List<CropAcresModel>()
    //        });
    //        //#1
    //        testConsents.Add(new GrowerConsentFormModel()
    //        {
    //            ContactName = "John Doe J1r",
    //            FarmName = "John Doe's Jr Farm1",
    //            ChequePayee = "John Doe Sr1",
    //            Address = "10500 Bluebulb Rd1",
    //            City = "Amber1",
    //            Province = "QC",
    //            PostalCode = "5N7Q4R",
    //            PhoneNumber = "3093456781",
    //            PhoneType = "Phone",
    //            Email = "john.doe.jr1@badmail.com",
    //            FarmPartnershipName = "John Doe's Farm1",
    //            PartnerContactName = "John Doe Sr1",
    //            TotalFarmAcres = "1015011",
    //            CropAcres = new List<CropAcresModel>()
    //        });
    //        //#2
    //        testConsents.Add(new GrowerConsentFormModel()
    //        {
    //            ContactName = "John Doe Jr1",
    //            FarmName = "John Doe's Jr Farm2",
    //            ChequePayee = "John Doe Sr2",
    //            Address = "10500 Bluebulb Rd2",
    //            City = "Amber2",
    //            Province = "QC",
    //            PostalCode = "5N7Q4Q",
    //            PhoneNumber = "3093456782",
    //            PhoneType = "Phone",
    //            Email = "john.doe.jr2@badmail.com",
    //            FarmPartnershipName = "John Doe's Farm2",
    //            PartnerContactName = "John Doe Sr2",
    //            TotalFarmAcres = "1015012",
    //            CropAcres = new List<CropAcresModel>()
    //        });
    //        //#3
    //        testConsents.Add(new GrowerConsentFormModel()
    //        {
    //            ContactName = "John Doe JRE",
    //            FarmName = "John Doe's Jr Farm2",
    //            ChequePayee = "John Doe Sr2",
    //            Address = "10500 Bluebulb Rd2",
    //            City = "Amber2",
    //            Province = "QC",
    //            PostalCode = "5N7Q4Q",
    //            PhoneNumber = "3093456782",
    //            PhoneType = "Phone",
    //            Email = "john.doe.jr25@badmail.com",
    //            FarmPartnershipName = "John Doe's Farm2",
    //            PartnerContactName = "John Doe Sr2",
    //            TotalFarmAcres = "1015015",
    //            CropAcres = new List<CropAcresModel>()
    //        });
    //        //#4
    //        testConsents.Add(new GrowerConsentFormModel()
    //        {
    //            ContactName = "John Doe JDK",
    //            FarmName = "John Doe's Jr JDK",
    //            ChequePayee = "John Doe JDK",
    //            Address = "10500 Bluebulb JDK",
    //            City = "AmberJDK",
    //            Province = "QC",
    //            PostalCode = "5N7T4Q",
    //            PhoneNumber = "3093456782",
    //            PhoneType = "Phone",
    //            Email = "john.doe.JDK@badmail.com",
    //            FarmPartnershipName = "John Doe's JDK",
    //            PartnerContactName = "John Doe JDK",
    //            TotalFarmAcres = "1015013",
    //            CropAcres = new List<CropAcresModel>()
    //        });
    //        //#5
    //        testConsents.Add(new GrowerConsentFormModel()
    //        {
    //            ContactName = "John Doe JDK1",
    //            FarmName = "John Doe's Jr JDK1",
    //            ChequePayee = "John Doe JDK1",
    //            Address = "10500 Bluebulb JDK1",
    //            City = "AmberJDK1",
    //            Province = "QC",
    //            PostalCode = "5N7T4Q",
    //            PhoneNumber = "3093456783",
    //            PhoneType = "Phone",
    //            Email = "john.doe.JDK1@badmail.com",
    //            FarmPartnershipName = "John Doe's JDK1",
    //            PartnerContactName = "John Doe JDK1",
    //            TotalFarmAcres = "1015013",
    //            CropAcres = new List<CropAcresModel>()
    //        });
    //        //#6
    //        testConsents.Add(new GrowerConsentFormModel()
    //        {
    //            ContactName = "John Doe JDK2",
    //            FarmName = "John Doe's Jr JDK2",
    //            ChequePayee = "John Doe JDK2",
    //            Address = "10500 Bluebulb JDK2",
    //            City = "AmberJDK2",
    //            Province = "QC",
    //            PostalCode = "5N7T4Q",
    //            PhoneNumber = "3093456783",
    //            PhoneType = "Phone",
    //            Email = "john.doe.JDK1@badmail.com",
    //            FarmPartnershipName = "John Doe's JDK1",
    //            PartnerContactName = "John Doe JDK1",
    //            TotalFarmAcres = "1015013",
    //            CropAcres = new List<CropAcresModel>()
    //        });
    //        //#7
    //        testConsents.Add(new GrowerConsentFormModel()
    //        {
    //            ContactName = "John Doe JDK3",
    //            FarmName = "John Doe's Jr JDK3",
    //            ChequePayee = "John Doe JDK3",
    //            Address = "10500 Bluebulb JDK3",
    //            City = "AmberJDK3",
    //            Province = "QC",
    //            PostalCode = "5N7T4Q",
    //            PhoneNumber = "3093456783",
    //            PhoneType = "Phone",
    //            Email = "john.doe.JDK3@badmail.com",
    //            FarmPartnershipName = "John Doe's JDK3",
    //            PartnerContactName = "John Doe JDK3",
    //            TotalFarmAcres = "1015015",
    //            CropAcres = new List<CropAcresModel>()
    //        });
    //        //#8
    //        testConsents.Add(new GrowerConsentFormModel()
    //        {
    //            ContactName = "John Doe JDK4",
    //            FarmName = "John Doe's Jr JDK4",
    //            ChequePayee = "John Doe JDK4",
    //            Address = "10500 Bluebulb JDK4",
    //            City = "AmberJDK4",
    //            Province = "QC",
    //            PostalCode = "5N7T4Q",
    //            PhoneNumber = "3093456783",
    //            PhoneType = "Phone",
    //            Email = "john.doe.JDK3@badmail.com",
    //            FarmPartnershipName = "John Doe's JDK4",
    //            PartnerContactName = "John Doe JDK4",
    //            TotalFarmAcres = "1015016",
    //            CropAcres = new List<CropAcresModel>()
    //        });
    //        return testConsents;
    //    }
    }
}
