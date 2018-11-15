using nstu_olympiad_site.Data;
using nstu_olympiad_site.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using nstu_olympiad_site.ViewModels;

namespace nstu_olympiad_site.Controllers
{
    // Summary:
    //  класс для регистрации новых пользователей“
    // 
    [Route("[controller]/[action]")]
    public class AccountsController : Controller
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger _logger;

        public AccountsController(UserManager<ApplicationUser> userManager, ApplicationDbContext applicationDbContext, ILogger<AccountsController> logger)
        {
            _userManager = userManager;
            _logger = logger;
            _appDbContext = applicationDbContext;
        }

        // POST accounts/register
        [HttpPost]
        public async Task<JsonResult> Register([FromBody]RegistrationViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return Json(BadRequest(ModelState));
            }

            var userIdentity = new ApplicationUser {
                UserName = model.Email,
                Email = model.Email,
            };
            var result = await _userManager.CreateAsync(userIdentity, model.Password);

            if(!result.Succeeded) {
                _logger.LogError("Failed to create account");
                return Json(BadRequest(result));
            }
            return Json(Ok());
        }

    }
}