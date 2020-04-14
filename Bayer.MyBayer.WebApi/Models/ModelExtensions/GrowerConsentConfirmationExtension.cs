using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Bayer.MyBayer.WebApi.Models.ModelExtensions
{
    public static class GrowerConsentConfirmationExtension
    {
        public static List<SqlParameter> GrowerConsentConfirmationExtensionSqlParams(this GrowerConsentConfirmationModel confirmation)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            var confirmationToken = new SqlParameter
            {
                ParameterName = "@ConfirmationToken",
                Value = confirmation.ConfirmationToken,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Size = 500
            };
            parameters.Add(confirmationToken);
            return parameters;
        }
    }
}

