using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using racing_webApp.Data;
using racing_webApp.Models;
using racing_webApp.ViewModels;

namespace racing_webApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly Db_context _db_context;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, Db_context db_context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db_context = db_context;
        }

        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AccountLoginViewModel VM)
        {
            if (!ModelState.IsValid)
            {
                return View(VM);
            }
            var user = await _userManager.FindByEmailAsync(VM.Email);
            if (user != null) {
                var passwordcheck = await _userManager.CheckPasswordAsync(user, VM.Password);
                if (passwordcheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, VM.Password, true, false);
                    return RedirectToAction("Index", "Race");
                }
                
            }
            TempData["Error"] = "Email or Password are inccorect";
            return View(VM);
        }
        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(AccountRegisterViewModel VM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var adminUser = await _userManager.FindByEmailAsync(VM.Email);
            if (adminUser == null)
            {
                int indexOFUserName = VM.Email.IndexOf('@');
                String userName = VM.Email.Substring(0, indexOFUserName);
                var newAdminUser = new AppUser()
                {
                    UserName = userName,
                    Email = VM.Email,
                    EmailConfirmed = true,
                    
                };
                var result = await _userManager.CreateAsync(newAdminUser, VM.Password); // Use VM.Password instead of VM.Email for the password
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newAdminUser, UserRoles.User);
                    return RedirectToAction("Index", "Club");
                }
                else
                {
                    // Handle errors during user creation
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(VM);
                }
            }
            else
            {
                TempData["Error"] = "User already exists.";
                return View(VM);
            }
        }

        
        public async Task<IActionResult> logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

    }
}
