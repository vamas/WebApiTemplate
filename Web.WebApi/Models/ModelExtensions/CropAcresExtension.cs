using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Bayer.MyBayer.WebApi.Models.ModelExtensions
{
    public static class CropAcresExtension
    {
        public static List<SqlParameter> CreateCropAcresParams(this CropAcresModel cropAcres, string commonId)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            var orgCommonIdParam = new SqlParameter
            {
                ParameterName = "@Org_CommonID",
                Value = commonId,
                Direction = ParameterDirection.Input,
                Size = 100
            };
            parameters.Add(orgCommonIdParam);
            var cropNameParam = new SqlParameter
            {
                ParameterName = "@CropName",
                Value = cropAcres.CropName,
                Direction = ParameterDirection.Input,
                Size = 100
            };
            parameters.Add(cropNameParam);
            var cropacresParam = new SqlParameter
            {
                ParameterName = "@CropAcres",
                Value = cropAcres.CropAcres,
                Direction = ParameterDirection.Input,
                Size = 20
            };
            parameters.Add(cropacresParam);

            return parameters;
        }
    }
}