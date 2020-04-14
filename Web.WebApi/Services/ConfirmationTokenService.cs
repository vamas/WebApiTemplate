using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bayer.MyBayer.WebApi.DAL;
using Bayer.MyBayer.WebApi.Models;
using Bayer.MyBayer.WebApi.Services.Definitions;
using Bayer.MyBayer.WebApi.Models.ModelExtensions;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;
using Bayer.MyBayer.WebApi.Infrastructure.ErrorHandling.Exceptions;
using Bayer.MyBayer.WebApi.BusinessLogic.ActionRunner;
using Bayer.MyBayer.WebApi.BusinessLogic.Model;
using Bayer.MyBayer.WebApi.BusinessLogic.DataInterfaces;
using System.Threading.Tasks;

namespace Bayer.MyBayer.WebApi.Services
{
    public class ConfirmationTokenService : IConfirmationTokenService
    {
        private readonly IEncodingService _encryptionService;
        private readonly int _tokenLifespan;
        private readonly int _tokenVersion;
        public ConfirmationTokenService(IEncodingService encryptionService, 
            int tokenLifespan, int tokenversion)
        {
            _encryptionService = encryptionService;
            _tokenLifespan = tokenLifespan;
            _tokenVersion = tokenversion;
        }
        public ConfirmationToken GenerateConfirmationToken(string commonId, string email)
        {
            var tokenDuration = _tokenLifespan;
            ConfirmationToken token = new ConfirmationToken()
            {
                Version = _tokenVersion,
                CommonId = commonId,
                Email = email,
                ExpiryDate = DateTime.Now.AddHours(tokenDuration)
            };
            return token;
        }

        public string TokenHash(ConfirmationToken token)
        {
            return _encryptionService.Encode(SerializeToken(token));
        }

        public bool ValidateConfirmationToken(string tokenhash)
        {
            ConfirmationToken token = GetTokenFromHash(tokenhash);
            if (token.CommonId == null)
                throw new ConsentNotFoundException();
            if (token.ExpiryDate < DateTime.Now)
                throw new ConfirmationTokenExpiredException();
            return true;
        }

        public ConfirmationToken GetTokenFromHash(string tokenhash)
        {
            try
            {
                ConfirmationToken token = DeserializeToken(_encryptionService.Decode(tokenhash));
                return token;
            }
            catch
            {
                throw new InvalidConfirmationTokenException("Invalid confirmation token provided");
            }
        }
        private string SerializeToken(ConfirmationToken token)
        {
            return JsonConvert.SerializeObject(token);
        }
        private ConfirmationToken DeserializeToken(string jsontoken)
        {
            return JsonConvert.DeserializeObject<ConfirmationToken>(jsontoken);
        }        
    }
}