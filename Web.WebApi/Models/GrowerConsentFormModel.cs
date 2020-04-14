using Bayer.MyBayer.WebApi.BusinessLogic.Model;
using Bayer.MyBayer.WebApi.Infrastructure.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bayer.MyBayer.WebApi.Models
{
    public class GrowerConsentFormModel : BusinessLogicEntity
    {
        [Key]
        public string GrowerConsentCommonId { get; set; }
        [ValidRequired]
        [ValidStringLength(100, Message = "ContactName cannot be more then 100 characters.")]
        public string ContactName { get; set; }
        [ValidRequired]
        [ValidStringLength(100, Message = "FarmName cannot be more then 100 characters.")]
        public string FarmName { get; set; }
        [ValidRequired]
        [ValidStringLength(100, Message = "ChequePayee cannot be more then 100 characters.")]
        public string ChequePayee { get; set; }
        [ValidRequired]
        [ValidStringLength(256, Message = "Address cannot be more then 256 characters.")]
        public string Address { get; set; }
        [ValidRequired]
        [ValidStringLength(60, Message = "City cannot be more then 60 characters.")]
        public string City { get; set; }
        [ValidRequired]
        [ValidStringLength(10, Message = "Province cannot be more then 10 characters.")]
        public string Province { get; set; }
        [ValidRequired]
        [ValidStringLength(10, Message = "Postal Code cannot be more then 10 characters.")]
        public string PostalCode { get; set; }
        [ValidRequired]
        [ValidStringLength(15, Message = "PhoneNumber cannot be more then 15 characters.")]
        public string PhoneNumber { get; set; }
        [ValidRequired]
        [ValidPhoneType]
        public string PhoneType { get; set;}
        [ValidRequired]
        [ValidStringLength(128, Message = "Email cannot be more then 128 characters.")]
        public string Email { get; set; }
        [ValidStringLength(100, Message = "FarmPartnershipName cannot be more then 100 characters.")]
        public string FarmPartnershipName { get; set; }
        [ValidStringLength(100, Message = "PartnerContactName cannot be more then 100 characters.")]
        public string PartnerContactName { get; set; }
        [ValidStringLength(20, Message = "TotalFarmAcres cannot be more then 20 characters.")]
        public string TotalFarmAcres { get; set; }
        public List<CropAcresModel> CropAcres { get; set; }
        public string ConfirmationToken { get; set; }
    }
}