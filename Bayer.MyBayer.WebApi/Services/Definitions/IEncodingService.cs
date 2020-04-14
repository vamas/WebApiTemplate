using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace Bayer.MyBayer.WebApi.Services.Definitions
{
    public interface IEncodingService
    {
        string Encode(string value);
        string Decode(string hash);
    }
}