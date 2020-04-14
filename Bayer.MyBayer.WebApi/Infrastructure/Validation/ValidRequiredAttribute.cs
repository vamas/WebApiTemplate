using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bayer.MyBayer.WebApi.Infrastructure.Validation
{
    public class ValidRequiredAttribute : ValidationAttributeBase
    {
        private readonly RequiredAttribute _requiredAttribute;

        public ValidRequiredAttribute()
        {
            _requiredAttribute = new RequiredAttribute();
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            bool result = _requiredAttribute.IsValid(value);
            if(value == null)
            {
                return ValidationError.LogResult(Logger, string.Format("A Required field was not provided."));
            }
            if(!result)
            {
                Type objType = value.GetType();
                string name = objType.Name;
                return ValidationError.LogResult(Logger, string.Format("Field: {0} is requried", name));
            }
            return ValidationResult.Success;
        }
    }
}