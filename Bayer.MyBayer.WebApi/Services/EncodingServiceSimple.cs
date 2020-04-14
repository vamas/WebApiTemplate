using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bayer.MyBayer.WebApi.Infrastructure.Encryption;
using Bayer.MyBayer.WebApi.Services.Definitions;

namespace Bayer.MyBayer.WebApi.Services
{
    public class EncodingServiceSimple : IEncodingService
    {
        public string Decode(string hash)
        {
            if (hash == null)
            {
                return null;
            }
            var bytesToBeDecoded = Convert.FromBase64String(hash);
            return Encoding.UTF8.GetString(bytesToBeDecoded);
        }

        public string Encode(string value)
        {
            if (value == null)
            {
                return null;
            }
            var bytesToBeEncoded = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(bytesToBeEncoded);
        }
    }
}