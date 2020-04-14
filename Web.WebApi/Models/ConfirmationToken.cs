using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bayer.MyBayer.WebApi.Models
{
    public class ConfirmationToken
    {
        public int Version { get; set; }
        public string CommonId { get; set; }
        public string Email { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}