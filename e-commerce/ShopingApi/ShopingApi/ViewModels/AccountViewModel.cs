using System.ComponentModel.DataAnnotations;

namespace ShopingApi.ViewModels
{
    public class AccountViewModel
    {
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email is requered .")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is requred .")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
