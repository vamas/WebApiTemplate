using Bayer.MyBayer.WebApi.BusinessLogic.Model;
using Bayer.MyBayer.WebApi.Infrastructure.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bayer.MyBayer.WebApi.Models
{
    public class GrowerConsentStatusModel : BusinessLogicEntity
    {
        [ValidRequired]
        [ValidStringLength(100, Message = "GrowerFormCommonId cannot be more then 100 characters.")]
        public string GrowerFormCommonId { get; set; }
        [ValidRequired]
        public bool GrowerConsent { get; set; }
        [ValidRequired]
        [ValidStringLength(100, Message = "GrowerEmailAddress cannot be more then 100 characters.")]
        public string GrowerEmailAddress { get; set; }
    }
}