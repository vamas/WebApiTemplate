using Bayer.MyBayer.WebApi.Infrastructure.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bayer.MyBayer.WebApi.Models
{
    public class GrowerPostModel
    {
        [Key]
        [ValidRequired]
        [ValidStringLength(10, Message = "RetailerCommondId can not be longer then 10 characters.")]
        public string RetailerCommondId { get; set; }
        [ValidRequired]
        [ValidStringLength(40, Message="Farm name can not be longer then 40 characters.")]
        public string FarmName { get; set; }
        //[ValidRequired]
        //public string FirstName { get; set; }
        //[ValidRequired]
        //public string LastName { get; set; }
        [ValidRequired]
        [ValidStringLength(256, Message="Street address cannot be longer then 256 characters.")]
        public string StreetAddress { get; set; }
        [ValidRequired]
        [ValidStringLength(10, Message="Province cannot be longer then 10 characters.")]
        public string Province { get; set; }
        [ValidRequired]
        [ValidStringLength(60, Message="Town cannot be longer then 60 characters.")]
        public string Town { get; set; }
        [ValidRequired]
        [ValidStringLength(10, Message="Postal code cannot be longer then 10 characters.")]
        public string PostalCode { get; set; }
        [ValidRequired]
        [ValidStringLength(15, Message="Phone number cannot be longer then 15 characters.")]
        public string PhoneNumber { get; set; }
        [ValidRequired]
        [ValidStringLength(128, Message="Email address cannot be longer then 128 characters.")]
        public string EmailAddress { get; set; }

    }
}