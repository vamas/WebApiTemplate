using Bayer.MyBayer.WebApi.Services.Definitions;
using System.Web.Http;
using System.Web.Http.Description;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using Bayer.MyBayer.WebApi.Models;
using Bayer.MyBayer.WebApi.Infrastructure.ErrorHandling.Exceptions;

namespace Bayer.MyBayer.WebApi.Controllers
{
    public class GrowerConsentFormController : ApiController
    {
        private readonly IGrowerConsentService _growerConsentService;

        public GrowerConsentFormController(IGrowerConsentService growerConsentService)
        {
            _growerConsentService = growerConsentService;
        }

        /// <summary>
        /// Passes consent information for a specific grower.
        /// </summary>
        /// <param name="consentForm"></param>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(bool))]
        public IHttpActionResult Post([FromBody]GrowerConsentFormModel consentForm)
        {
            if(!ModelState.IsValid)
            {
                //"The Grower Model provided was not valid"
                return BadRequest(ModelState);
            }
            try
            {
                var createdGrowerConsent = _growerConsentService.CreateGrowerConsent(consentForm);
                return Ok(createdGrowerConsent);
            }
            catch (GrowerConsentExistsException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
