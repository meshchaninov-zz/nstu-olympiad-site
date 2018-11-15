using System.ComponentModel.DataAnnotations;

namespace nstu_olympiad_site.ViewModels
{
    public class RegistrationViewModel
    {
        [Display(Name = "Email")]
        public string Email {get; set;}

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password {get; set;}

    }
}