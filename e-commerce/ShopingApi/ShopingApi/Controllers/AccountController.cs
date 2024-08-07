using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ShopingApi.Data;
using ShopingApi.Models;
using ShopingApi.ViewModels;

namespace ShopingApi.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly Db_Context _db_context;

        public IActionResult Index()
        {
            return View();
        }

        public AccountController(UserManager<AppUser> UserManager,SignInManager<AppUser> SignInManager,Db_Context Db_Context)
        {
            _userManager = UserManager;
            _signInManager = SignInManager;
            _db_context = Db_Context;
        }
        [HttpPost]
        [Route("api/account/login")]
        public async Task<IActionResult> Login([FromBody] AccountViewModel VM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(VM.Email);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, VM.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, VM.Password, true, false);
                    if (result.Succeeded)
                    {
                        return Ok(new { Message = "Login successful" });
                    }
                }
            }

            return Unauthorized(new { Error = "Email or Password are incorrect" });
        }

        [HttpPost]
        [Route("api/account/register")]
        public async Task<IActionResult> Register([FromBody] AccountRegisterViewModel VM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var adminUser = await _userManager.FindByEmailAsync(VM.Email);
            if (adminUser == null)
            {
                int indexOFUserName = VM.Email.IndexOf('@');
                string userName = VM.Email.Substring(0, indexOFUserName);
                var newAdminUser = new AppUser()
                {
                    UserName = userName,
                    Email = VM.Email,
                    EmailConfirmed = true,
                };
                var result = await _userManager.CreateAsync(newAdminUser, VM.Password);
                
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newAdminUser, VM.Role);
                    return Ok(new { RedirectUrl = Url.Action("Index") });
                }
                else
                {
                    // Handle errors during user creation
                    return BadRequest(result.Errors);
                }
            }
            else
            {
                return BadRequest(new { Error = "User already exists." });
            }
        }


    }
}
