using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SharedEntities.Auth;

namespace MarineraWebApi.Controllers;

[Route("[controller]")]
public class AuthController : Controller
{
    private readonly ILogger<ConcoursesController> _logger;
    
    private readonly UserManager<IdentityUser> userManager;
    private readonly IConfiguration configuration;
    private readonly SignInManager<IdentityUser> signInManager;

    public AuthController(ILogger<ConcoursesController> logger, UserManager<IdentityUser> userManager, IConfiguration configuration, SignInManager<IdentityUser> signInManager)
    {
        _logger = logger;
        this.userManager = userManager;
        this.configuration = configuration;
        this.signInManager = signInManager;
    }

    // GET
    [HttpGet("oauth2redirect")]
    public IActionResult OAuth2Redirect(string code)
    {
        // Aquí puedes manejar el código de autorización. Por ejemplo, podrías guardarlo en la base de datos
        // y luego redirigir de nuevo a tu aplicación de .NET MAUI con un identificador que tu aplicación de .NET MAUI pueda usar para recuperar el código de autorización.
        _logger.LogInformation($"Código de autorización: {code}");
        var redirectUrl = $"myapp-scheme://auth?code={code}";
        return Redirect(redirectUrl);
        
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> Login([FromBody] LoginModel request)
    {
        var user = await userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            return BadRequest("Usuario no encontrado");
        }
        var result = await signInManager.PasswordSignInAsync(user, request.Password, false, false);
        if (result.Succeeded)
        {
            return await BuildToken(request); 
        }
        else
        {
            return BadRequest("Login incorrecto");
        }
    }
    [HttpPost("register")]
    public async Task<ActionResult<AuthResponse>> Register([FromBody] LoginModel request)
    {
        var user = new IdentityUser(){UserName = request.Email, Email = request.Email};
        var result = await userManager.CreateAsync(user, request.Password);
        if (result.Succeeded)
        {
            return await BuildToken(request:request); 
        }
        else
        {
            return BadRequest(result.Errors);
        }

    }
    private async Task<AuthResponse> BuildToken(LoginModel request)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Email, request.Email)
        };
        var expires = DateTime.Now.AddYears(1);
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtKey"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(null,
            null,
            claims,
            expires: expires,
            signingCredentials: creds);
        return new AuthResponse()
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expires = expires
        };
        
    }
    
}