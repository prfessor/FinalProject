using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey) //jwt de kullanılacak securitykey ve algoritmayı belirler.
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature); //anahtar olarak securityKey,
                                                                                                //şifreleme olarak da hmasha yı kullan
        }
    }
}
