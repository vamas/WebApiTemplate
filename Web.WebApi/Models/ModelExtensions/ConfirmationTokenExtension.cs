using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Bayer.MyBayer.WebApi.Models.ModelExtensions
{
    public static class ConfirmationTokenExtension
    {
        public static List<SqlParameter> ConfirmationTokenExtensionSqlParams(this ConfirmationToken token)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            var commonId = new SqlParameter
            {
                ParameterName = "@Org_CommonID",
                Value = token.CommonId,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Size = 10
            };
            parameters.Add(commonId);
            var email = new SqlParameter
            {
                ParameterName = "@Email",
                Value = token.Email,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Size = 128
            };
            parameters.Add(email);
            var result = new SqlParameter
            {
                ParameterName = "@result",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };
            parameters.Add(result);
            return parameters;
        }
    }
}

