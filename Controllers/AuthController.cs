using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using nstu_olympiad_site.ViewModels;
using System.Threading.Tasks;
using nstu_olympiad_site.Utils.Auth;
using nstu_olympiad_site.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Claims;

namespace nstu_olympiad_site.Controllers
{
    [Route("[controller]/[action]")]
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtFactory _jwtFactory;
        private readonly JwtIssuerOptions _jwtOptions;

        public AuthController(UserManager<ApplicationUser> userManager, IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions)
        {
            _userManager = userManager;
            _jwtFactory = jwtFactory;
            _jwtOptions = jwtOptions.Value;
        }

        // POST auth/login
        public async Task<JsonResult> Login([FromBody]LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(BadRequest(ModelState));
            }

            var identity = await GetClaimsIdentity(model.Email, model.Password);
            if (identity == null)
            {
                return(Json(BadRequest()));
            }

            var jwt = await Tokens.GenerateJwt(identity, _jwtFactory, model.Email, _jwtOptions, new JsonSerializerSettings {
                Formatting = Formatting.Indented
            });

            return Json(JObject.Parse(jwt));

        }

        private async Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                return await Task.FromResult<ClaimsIdentity>(null);
            }

            //get user
            var userToVerify = await _userManager.FindByEmailAsync(userName);

            if(userToVerify == null) 
            {
                return await Task.FromResult<ClaimsIdentity>(null);
            }

            if(await _userManager.CheckPasswordAsync(userToVerify, password))
            {
                return await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(userName, userToVerify.Id));
            }

            //Credentials are invalid, or account doesn't exist
            return await Task.FromResult<ClaimsIdentity>(null);
        }
    }
}