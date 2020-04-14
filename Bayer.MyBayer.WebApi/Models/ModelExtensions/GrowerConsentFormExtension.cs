using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Bayer.MyBayer.WebApi.Models.ModelExtensions
{
    public static class GrowerConsentFormExtension
    {
        public static List<SqlParameter> CreateGrowerConsentSqlParams(this GrowerConsentFormModel consentForm)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            var contactNameParam = new SqlParameter
            {
                ParameterName = "@ContactName",
                Value = consentForm.ContactName,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Size = 100
            };
            parameters.Add(contactNameParam);
            var farmNameParam = new SqlParameter
            {
                ParameterName = "@FarmName",
                Value = consentForm.FarmName,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Size = 100
            };
            parameters.Add(farmNameParam);
            var chequePayeeParam = new SqlParameter
            {
                ParameterName = "@ChequePayee",
                Value = consentForm.ChequePayee,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Size = 100
            };
            parameters.Add(chequePayeeParam);
            var addressParam = new SqlParameter
            {
                ParameterName = "@address",
                Value = consentForm.Address,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Size = 256
            };
            parameters.Add(addressParam);
            var cityParam = new SqlParameter
            {
                ParameterName = "@city",
                Value = consentForm.City,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Size = 60
            };
            parameters.Add(cityParam);
            var provinceParam = new SqlParameter
            {
                ParameterName = "@province",
                Value = consentForm.Province,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Size = 10
            };
            parameters.Add(provinceParam);
            var postalCodeParam = new SqlParameter
            {
                ParameterName = "@postalCode",
                Value = consentForm.PostalCode,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Size = 10
            };
            parameters.Add(postalCodeParam);

            var phoneNumberParam = new SqlParameter
            {
                ParameterName = "@phonenumber",
                Value = consentForm.PhoneNumber,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Size = 15
            };
            parameters.Add(phoneNumberParam);

            var phoneTypeParam = new SqlParameter
            {
                ParameterName = "@phonetype",
                Value = consentForm.PhoneType,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Size = 10
            };
            parameters.Add(phoneTypeParam);

            var emailAddressParam = new SqlParameter
            {
                ParameterName = "@emailAddress",
                Value = consentForm.Email,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Size = 128
            };
            parameters.Add(emailAddressParam);
            var partnerNameParam = new SqlParameter
            {
                ParameterName = "@FarmPartnershipName",
                Value = consentForm.FarmPartnershipName,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Size = 100
            };
            parameters.Add(partnerNameParam);
            var partnerContactNameParam = new SqlParameter
            {
                ParameterName = "@PartnerContactName",
                Value = consentForm.PartnerContactName,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Size = 100
            };
            parameters.Add(partnerContactNameParam);
            var totalFarmAcresParam = new SqlParameter
            {
                ParameterName = "@TotalFarmAcres",
                Value = consentForm.TotalFarmAcres,
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                Size = 20
            };
            parameters.Add(totalFarmAcresParam);
            var retCommonIdParam = new SqlParameter
            {
                ParameterName = "@Org_CommonID",
                Value = DBNull.Value,
                SqlDbType = SqlDbType.Decimal,
                Direction = ParameterDirection.InputOutput,
                Size = 10
            };
            parameters.Add(retCommonIdParam);
            return parameters;
        }
    }
}