using System.ComponentModel.DataAnnotations;

namespace racing_webApp.ViewModels
{
    public class AccountLoginViewModel
    {
        [Display(Name ="Email Address")]
        [Required (ErrorMessage ="Email is requered .")]
        public string Email { get; set;}

        [Required (ErrorMessage ="Password is requred .")]
        [DataType(DataType.Password)]
        public string Password { get; set;}
    }
}
