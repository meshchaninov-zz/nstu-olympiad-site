using nstu_olympiad_site.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Security.Principal;
using System;
using Microsoft.Extensions.Options;

namespace nstu_olympiad_site.Utils.Auth
{
    public class JwtFactory : IJwtFactory
    {
        private readonly JwtIssuerOptions _jwtOptions;
        public JwtFactory(IOptions<JwtIssuerOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }

        public async Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Jti, await _jwtOptions.JtiGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64),
                identity.FindFirst("rol"),
                identity.FindFirst("id")
            };

            // Create the JWT security token and encode id.
            var jwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                notBefore: _jwtOptions.NotBefore,
                expires: _jwtOptions.Expiration,
                signingCredentials: _jwtOptions.SigningCredentials
            );
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }

        public ClaimsIdentity GenerateClaimsIdentity(string userName, string id)
        {
            return new ClaimsIdentity(new GenericIdentity(userName, "Token"), new[]
            {
                new Claim("id", id),
                new Claim("rol", "api_access")
            });
        }

        private static long ToUnixEpochDate(DateTime date)
        {
            return (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
        }
    }
}