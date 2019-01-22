using BooksAppCore.Services;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using BooksAppCore;

namespace BooksInfrastructure.Services
{
    public class JWTService : IJWTService
    {
        private AuthOptions authOptions;

        public JWTService(IOptions<AuthOptions> authOptions)
        {
            this.authOptions = authOptions.Value;
        }

        public string GetJwt(ClaimsIdentity identity)
        {
            var now = DateTime.Now;
            JwtSecurityToken token = new JwtSecurityToken(
                    issuer: authOptions.Issuer,
                    audience: authOptions.Audience,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.AddMinutes(authOptions.AccessLifetime),
                    signingCredentials: new SigningCredentials(authOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            string encodedJwt = new JwtSecurityTokenHandler().WriteToken(token);

            return encodedJwt;
        }
    }
}
