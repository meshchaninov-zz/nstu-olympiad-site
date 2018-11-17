using System.Threading.Tasks;
using System.Security.Claims;
using nstu_olympiad_site.Models;
using System.Linq;
using Newtonsoft.Json;
using nstu_olympiad_site.ViewModels;

namespace nstu_olympiad_site.Utils.Auth
{
    public class Tokens
    {
        public static async Task<string> GenerateJwt(ClaimsIdentity identity, IJwtFactory jwtFactory, string userName, JwtIssuerOptions jwtIssuerOptions, JsonSerializerSettings serializerSettings)
        {
            var response = new
            {
                id = identity.Claims.Single(c => c.Type == "id").Value,
                auth_token = await jwtFactory.GenerateEncodedToken(userName, identity),
                expires_in = (int)jwtIssuerOptions.ValidFor.TotalSeconds
            };

            return JsonConvert.SerializeObject(response, serializerSettings);
        }
    }
}