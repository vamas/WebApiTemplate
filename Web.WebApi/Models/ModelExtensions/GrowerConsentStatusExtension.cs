using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Bayer.MyBayer.WebApi.Models.ModelExtensions
{
    public static class GrowerConsentStatusExtension
    {
        public static List<SqlParameter> CreateCropAcresParams(this GrowerConsentStatusModel consent)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            var growerConsentIdParam = new SqlParameter
            {
                ParameterName = "@GrowerConsentID",
                Value = consent.GrowerFormCommonId,
                Direction = ParameterDirection.Input,
                Size = 100
            };
            parameters.Add(growerConsentIdParam);

            var growerEmailAddressParam = new SqlParameter
            {
                ParameterName = "@GrowerEmailAddress",
                Value = consent.GrowerEmailAddress,
                Direction = ParameterDirection.Input,
                Size = 100
            };
            parameters.Add(growerEmailAddressParam);

            var growerConsentParam = new SqlParameter
            {
                ParameterName = "@GrowerConsent",
                Value = consent.GrowerConsent,
                Direction = ParameterDirection.Input,
                Size = 1
            };
            parameters.Add(growerConsentParam);

            return parameters;
        }
    }
}