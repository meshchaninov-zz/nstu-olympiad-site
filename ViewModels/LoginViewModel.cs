using System.ComponentModel.DataAnnotations;
namespace nstu_olympiad_site.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Email")]
        public string Email {get; set;}
        [Display(Name = "Email")]
        public string Password {get; set;}
        
    }
}