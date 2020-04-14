using Bayer.MyBayer.WebApi.BusinessLogic.Model;
using Bayer.MyBayer.WebApi.Infrastructure.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bayer.MyBayer.WebApi.Models
{
    public class CropAcresModel : BusinessLogicEntity
    {
        public string CropId { get; set; }

        [ValidStringLength(100, Message = "CropName Cannot be more then 100 characters.")]
        public string CropName { get; set; }
        public decimal CropAcres { get; set; }
        public string GrowerConsentCommonId { get; set; }
    }
}