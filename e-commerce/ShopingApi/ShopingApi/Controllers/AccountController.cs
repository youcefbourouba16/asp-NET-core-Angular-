using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ShopingApi.Data;
using ShopingApi.Models;
using ShopingApi.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShopingApi.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly Db_Context _db_context;
        private readonly IConfiguration _configuration;
        public IActionResult Index()
        {
            return View();
        }

        public AccountController(UserManager<AppUser> UserManager,SignInManager<AppUser> SignInManager,
            Db_Context Db_Context,IConfiguration configuration)
        {
            _userManager = UserManager;
            _signInManager = SignInManager;
            _db_context = Db_Context;
            _configuration = configuration;
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
                        var token = GenerateJwtToken(user);
                        return Ok(new { Token = token });

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
                    return Ok(new { Message = "User registered successfully" });
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
        private string GenerateJwtToken(IdentityUser user)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
