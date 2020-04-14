using Bayer.MyBayer.WebApi.Models;
using Bayer.MyBayer.WebApi.Services.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Bayer.MyBayer.WebApi.Controllers
{
    public class GrowerConsentStatusController : ApiController
    {

        private readonly IGrowerConsentService _growerConsentService;

        public GrowerConsentStatusController(IGrowerConsentService growerConsentService)
        {
            _growerConsentService = growerConsentService;
        }

        /// <summary>
        /// Updates consent information for a specific grower.
        /// </summary>
        /// <param name="consentStatus"></param>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(bool))]
        public IHttpActionResult Post([FromBody]GrowerConsentStatusModel consentStatus)
        {
            if (!ModelState.IsValid)
            {
                //"The Grower Model provided was not valid"
                return BadRequest(ModelState);
            }
            var updatedConsent = _growerConsentService.UpdateGrowerConsentStatus(consentStatus);
            return Ok(updatedConsent);
        }
    }
}
