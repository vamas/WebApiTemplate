using System;
using System.Collections.Generic;
using System.Linq;
using Bayer.MyBayer.WebApi.Infrastructure.Encryption;
using Bayer.MyBayer.WebApi.Services.Definitions;
using Bayer.MyBayer.WebApi.Infrastructure.ErrorHandling.Exceptions;

namespace Bayer.MyBayer.WebApi.Services
{
    public class EncodingServiceSHA : IEncodingService
    {
        private readonly string _password;
        public EncodingServiceSHA(string password)
        {
            _password = password;
        }
        public string Decode(string hash)
        {
            if (!Cipher.ValidateHash(hash, _password))
                throw new InvalidConfirmationTokenException("Confirmation token cannot be decrypted");
            return Cipher.Decrypt(hash, _password);
        }
        public string Encode(string value)
        {
            return Cipher.Encrypt(value, _password);
        }
    }
}