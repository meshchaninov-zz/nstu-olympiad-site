using System.Security.Claims;
using System.Threading.Tasks;

namespace nstu_olympiad_site.Utils.Auth
{
    public interface IJwtFactory
    {
        Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity);
        ClaimsIdentity GenerateClaimsIdentity(string userName, string id);
    }
}