using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Bayer.MyBayer.WebApi.Models.ModelExtensions
{
    public static class GrowerPostModelExtension
    {
        public static List<SqlParameter> CreateGrowerPostModelSqlParameters(this GrowerPostModel grower)
        {
            List<SqlParameter> paramsList = new List<SqlParameter>();
            var passwordParam = new SqlParameter
            {
                ParameterName = "@password",
                Value = DBNull.Value,
                Direction = ParameterDirection.Input,
                Size = 35
            };
            paramsList.Add(passwordParam);

            var findCodeParam = new SqlParameter
            {
                ParameterName = "@findCode",
                Value = "",
                Direction = ParameterDirection.Input,
                Size = 6
            };
            paramsList.Add(findCodeParam);

            var updatedDateParam = new SqlParameter
            {
                ParameterName = "@updateDate",
                Value = DateTime.Now,
                Direction = ParameterDirection.Input
            };
            paramsList.Add(updatedDateParam);

            var orgNameParam = new SqlParameter
            {
                ParameterName = "@organizationName",
                Value = grower.FarmName,
                Direction = ParameterDirection.Input,
                Size = 40
            };
            paramsList.Add(orgNameParam);

            var phoneAreaCodeParam = new SqlParameter
            {
                ParameterName = "@phoneAreaCode",
                Value = DBNull.Value,
                Direction = ParameterDirection.Input,
                Size = 10
            };
            paramsList.Add(phoneAreaCodeParam);

            var phoneNumberParam = new SqlParameter
            {
                ParameterName = "@phoneNumber",
                Value = grower.PhoneNumber,
                Direction = ParameterDirection.Input,
                Size = 15
            };
            paramsList.Add(phoneNumberParam);

            var faxAreaCodeParam = new SqlParameter
            {
                ParameterName = "@faxAreaCode",
                Value = DBNull.Value,
                Direction = ParameterDirection.Input,
                Size = 10
            };
            paramsList.Add(faxAreaCodeParam);

            var faxNumberParam = new SqlParameter
            {
                ParameterName = "@faxNumber",
                Value = DBNull.Value,
                Direction = ParameterDirection.Input,
                Size = 15
            };
            paramsList.Add(faxNumberParam);

            var otherAreaCodeParam = new SqlParameter
            {
                ParameterName = "@otherAreaCode",
                Value = DBNull.Value,
                Direction = ParameterDirection.Input,
                Size = 10
            };
            paramsList.Add(otherAreaCodeParam);

            var otherPhoneNumber = new SqlParameter
            {
                ParameterName = "@otherPhoneNumber",
                Value = DBNull.Value,
                Direction = ParameterDirection.Input,
                Size = 15
            };
            paramsList.Add(otherPhoneNumber);

            var emailAddressParam = new SqlParameter
            {
                ParameterName = "@emailAddress",
                Value = grower.EmailAddress,
                Direction = ParameterDirection.Input,
                Size = 128
            };
            paramsList.Add(emailAddressParam);

            var webUrlParam = new SqlParameter
            {
                ParameterName = "@webUrl",
                Value = DBNull.Value,
                Direction = ParameterDirection.Input,
                Size = 128
            };
            paramsList.Add(webUrlParam);

            var streetAddressParam = new SqlParameter
            {
                ParameterName = "@address",
                Value = grower.StreetAddress,
                Direction = ParameterDirection.Input,
                Size = 256
            };
            paramsList.Add(streetAddressParam);

            var cityParam = new SqlParameter
            {
                ParameterName = "@city",
                Value = grower.Town,
                Direction = ParameterDirection.Input,
                Size = 60
            };
            paramsList.Add(cityParam);

            var provinceParam = new SqlParameter
            {
                ParameterName = "@province",
                Value = grower.Province,
                Direction = ParameterDirection.Input,
                Size = 10
            };
            paramsList.Add(provinceParam);

            var postalCodeParam = new SqlParameter
            {
                ParameterName = "@postalCode",
                Value = grower.PostalCode,
                Direction = ParameterDirection.Input,
                Size = 10
            };
            paramsList.Add(postalCodeParam);

            var activeParam = new SqlParameter
            {
                ParameterName = "@active",
                Value = DBNull.Value,
                Direction = ParameterDirection.Input
            };
            paramsList.Add(activeParam);

            var xmlRawTextParam = new SqlParameter
            {
                ParameterName = "@xmlRawText",
                Value = DBNull.Value,
                Direction = ParameterDirection.Input,
                Size = 4000
            };
            paramsList.Add(xmlRawTextParam);

            var orgIdParam = new SqlParameter
            {
                ParameterName = "@Org_ID",
                Value = DBNull.Value,
                Direction = ParameterDirection.Input
            };
            paramsList.Add(orgIdParam);

            var orgCommonIdParam = new SqlParameter
            {
                ParameterName = "@Org_CommonID",
                Value = DBNull.Value,
                Direction = ParameterDirection.Input
            };
            paramsList.Add(orgCommonIdParam);

            var orgStatusParam = new SqlParameter
            {
                ParameterName = "@Org_Status",
                Value = DBNull.Value,
                Direction = ParameterDirection.Input
            };
            paramsList.Add(orgStatusParam);

            var currentFlagParam = new SqlParameter
            {
                ParameterName = "@CurrentFlag",
                Value = DBNull.Value,
                Direction = ParameterDirection.Input
            };
            paramsList.Add(currentFlagParam);


            var effectiveFromParam = new SqlParameter
            {
                ParameterName = "@EffectiveFrom",
                Value = DBNull.Value,
                Direction = ParameterDirection.Input
            };
            paramsList.Add(effectiveFromParam);

            var effectiveToParam = new SqlParameter
            {
                ParameterName = "@EffectiveTo",
                Value = DBNull.Value,
                Direction = ParameterDirection.Input
            };
            paramsList.Add(effectiveToParam);

            var deletedParam = new SqlParameter
            {
                ParameterName = "@Deleted",
                Value = DBNull.Value,
                Direction = ParameterDirection.Input
            };
            paramsList.Add(deletedParam);


            var batchOriginalParam = new SqlParameter
            {
                ParameterName = "@BatchOriginal",
                Value = DBNull.Value,
                Direction = ParameterDirection.Input
            };
            paramsList.Add(batchOriginalParam);

            var frenchParam = new SqlParameter
            {
                ParameterName = "@French",
                Value = DBNull.Value,
                Direction = ParameterDirection.Input
            };
            paramsList.Add(frenchParam);

            var retCommonIdParam = new SqlParameter
            {
                ParameterName = "@Ret_CommonID",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Value = grower.RetailerCommondId,
                Size = 10
            };
            paramsList.Add(retCommonIdParam);

            return paramsList;
        }
        
    }
}