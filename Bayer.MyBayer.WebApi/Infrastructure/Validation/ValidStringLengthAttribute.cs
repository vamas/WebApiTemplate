using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bayer.MyBayer.WebApi.Infrastructure.Validation
{
    public class ValidStringLengthAttribute : ValidationAttributeBase
    {
        private readonly StringLengthAttribute _stringLengthAttribute;
        public string Message { get; set; }

        public ValidStringLengthAttribute(int maximumLength)
        {
            _stringLengthAttribute = new StringLengthAttribute(maximumLength);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            bool result = _stringLengthAttribute.IsValid(value);
            if (!result)
            {
                if (string.IsNullOrEmpty(Message))
                {
                    return ValidationError.LogResult(Logger, "String length out of bounds");
                }
                return ValidationError.LogResult(Logger, Message);
            }
            return ValidationResult.Success;
        }
    }
}