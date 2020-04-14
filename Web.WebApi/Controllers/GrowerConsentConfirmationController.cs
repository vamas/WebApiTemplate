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
using Bayer.MyBayer.WebApi.ErrorHandling;

namespace Bayer.MyBayer.WebApi.Controllers
{
    public class GrowerConsentConfirmationController : ApiController
    {
        private readonly IGrowerConsentService _growerConsentService;

        public GrowerConsentConfirmationController(IGrowerConsentService growerConsentService)
        {
            _growerConsentService = growerConsentService;
        }

        [HttpPost]
        [ResponseType(typeof(bool))]
        public IHttpActionResult Post([FromBody]GrowerConsentConfirmationModel consentConfirmation)
        { 
            if (!ModelState.IsValid)
            {
                //"The Grower Model provided was not valid"
                return BadRequest(ModelState);
            }
            try
            {
                var result = _growerConsentService.ConfirmGrowerConsent(consentConfirmation);
                return Ok(result);
            }
            catch(InvalidConfirmationTokenException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ConfirmationTokenExpiredException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ConsentNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}


