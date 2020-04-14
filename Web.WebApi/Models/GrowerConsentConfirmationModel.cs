using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Bayer.MyBayer.WebApi.Models
{
    public class GrowerConsentConfirmationModel
    {
        [Key]
        public string ConfirmationToken { get; set; }
    }
}


