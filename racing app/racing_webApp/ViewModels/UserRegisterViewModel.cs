using System.ComponentModel.DataAnnotations;

namespace racing_webApp.ViewModels
{
    public class UserRegisterViewModel
    {
        [Display(Name ="Email adresso")]
        [Required (ErrorMessage ="Email Adress required .")]
        public string  Email { get; set; }

        [Required (ErrorMessage ="password is required")]
        [DataType(DataType.Password)]
        public string  Password { get; set; }
        [Required (ErrorMessage ="confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="passwrod do not match .")]
        public string  Conffpassword { get; set; }
    }
}
