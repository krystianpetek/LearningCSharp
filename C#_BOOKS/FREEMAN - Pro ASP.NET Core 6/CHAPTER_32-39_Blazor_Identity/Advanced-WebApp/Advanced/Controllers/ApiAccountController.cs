using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Advanced.Controllers;

[ApiController]
[Route("/api/account")]
public class ApiAccountController : ControllerBase
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IConfiguration _configuration;


    public ApiAccountController(
        SignInManager<IdentityUser> signInManager, 
        UserManager<IdentityUser> userManager, 
        IConfiguration configuration)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _configuration = configuration;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] Credentials credentials)
    {
        Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(credentials.Username, credentials.Password, false, false);
        if (signInResult.Succeeded)
            return Ok();
        return Unauthorized();
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return Ok();
    }

    [HttpPost("token")]
    public async Task<IActionResult> Token([FromBody] Credentials credentials)
    {
        if(await CheckPassword(credentials))
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            byte[] secret = Encoding.ASCII.GetBytes(_configuration["jwtSecret"]);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, credentials.Username)
                }),
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(secret),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = handler.CreateToken(descriptor);
            return Ok(new
            {
                success = true,
                token = handler.WriteToken(token)
            });
        }
        return Unauthorized();
    }

    private async Task<bool> CheckPassword(Credentials credentials)
    {
        IdentityUser user = await _userManager.FindByNameAsync(credentials.Username);
        if (user != null)
            return (await _signInManager.CheckPasswordSignInAsync(user, credentials.Password, true)).Succeeded;
        return false;
    }

    public class Credentials
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
