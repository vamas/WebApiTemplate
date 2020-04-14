using Bayer.MyBayer.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bayer.MyBayer.WebApi.Services.Definitions
{
    public interface IConfirmationTokenService
    {
        ConfirmationToken GenerateConfirmationToken(string commonId, string email);
        bool ValidateConfirmationToken(string tokenhash);
        ConfirmationToken GetTokenFromHash(string tokenhash);        
        string TokenHash(ConfirmationToken token);
    }
}
