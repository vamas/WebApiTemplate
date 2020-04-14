using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bayer.MyBayer.WebApi.Infrastructure.Validation
{
    public class ValidPhoneType : ValidationAttributeBase
    {

        private List<string> phoneTypes = new List<string> { "phone", "mobile", "fax", "other" };
        public string Message { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string valueString = (string)value;
            string lowerString = valueString.ToLower();
            if (!phoneTypes.Any(str => str.Contains(lowerString)))
            {
                if (string.IsNullOrEmpty(Message))
                {
                    return ValidationError.LogResult(Logger, "Phone Type does not match accepted values.");
                }
                return ValidationError.LogResult(Logger, Message);
            }
            return ValidationResult.Success;
        }
    }
}