using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShopingApi.Models;
using ShopingApi.ViewModels.Account;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShopingApi.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
            if (user != null && await _userManager.CheckPasswordAsync(user, VM.Password))
            {
                var result = await _signInManager.PasswordSignInAsync(user, VM.Password, true, false);
                if (result.Succeeded)
                {
                    var token = await GenerateJwtToken(user);

                    var cookieOptions = new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true, // Secure for HTTPS
                        SameSite = SameSiteMode.Strict,
                        Expires = DateTime.UtcNow.AddHours(5)
                    };
                    Response.Cookies.Append("jwt", token, cookieOptions);

                    return Ok(new { Username = user.UserName });
                }
            }

            return Unauthorized(new { Error = "Email or Password are incorrect" });
        }
        [HttpGet]
        [Route("api/account/isAuthenticated")]
        public IActionResult IsAuthenticated()
        {
            if (User.Identity.IsAuthenticated)
            {
                return Ok(true);
            }
            return Ok(false);
        }

        [HttpPost]
        [Route("api/account/logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return Ok();
        }

        [HttpPost]
        [Route("api/account/register")]
        public async Task<IActionResult> Register([FromBody] AccountRegisterViewModel VM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingUser = await _userManager.FindByEmailAsync(VM.Email);
            if (existingUser == null)
            {
                var userName = VM.Email.Substring(0, VM.Email.IndexOf('@'));
                var newUser = new AppUser { UserName = userName, Email = VM.Email, EmailConfirmed = true };

                var result = await _userManager.CreateAsync(newUser, VM.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newUser, VM.Role);
                    return Ok(new { Message = "User registered successfully" });
                }

                return BadRequest(result.Errors);
            }

            return BadRequest(new { Error = "User already exists." });
        }

        private async Task<string> GenerateJwtToken(AppUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            // Add role claims
            claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

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
