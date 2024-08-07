using Microsoft.AspNetCore.Identity;

namespace ShopingApi.Models
{
    public class AppUser : IdentityUser
    {
        
        string role { get; set; }


    }
}
