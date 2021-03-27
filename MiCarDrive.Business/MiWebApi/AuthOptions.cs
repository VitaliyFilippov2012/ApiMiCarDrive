using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace MiWebApi
{
    public class AuthOptions
    {
        public const string ISSUER = "AuthServerCore";
        public const string AUDIENCE = "MiCarDrive";
        const string KEY = "vitaliy_filippov_poibms4_8";
        public const int LIFETIME = 60;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }

        public static TokenValidationParameters GetValidatingParameters()
        {
            return new TokenValidationParameters()
            {
                RequireExpirationTime = true,
                ValidateIssuer = true,
                ValidIssuer = ISSUER,
                ValidAudience = AUDIENCE,
                ValidateAudience = true,
                IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey()
            };
        }
    }
}
