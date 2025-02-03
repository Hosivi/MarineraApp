using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using MarineraApp.ViewModels.Login;
using Microsoft.Extensions.Configuration;
using SharedEntities.Auth;

namespace MarineraApp.Services;

public class AuthService : IAuthService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    private string? BaseUrl => !RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
        ? _configuration["AndroidBaseUrl"]
        : _configuration["WindowsBaseUrl"];

    public AuthService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<WebAuthenticatorResult> LoginWithGoogleAsync()
    {
        var authresult = await WebAuthenticator.AuthenticateAsync(
            new Uri("https://accounts.google.com"), new Uri("localhost:5000"));
        return authresult;
    }

    public async Task<AuthResponse> Login(LoginModel loginModel)
    {
        //var authResult = await _httpClient.PostAsync($"https://10.0.2.2:7047/Auth/login",
        //    new StringContent(JsonSerializer.Serialize(loginModel), Encoding.UTF8,
        //        "application/json"));
        var authResult = _httpClient.PostAsJsonAsync<LoginModel>("https://10.0.2.2:7047/Auth/login", loginModel);
        Console.WriteLine($"login: {authResult.Result}");
        
        return new AuthResponse()
        {
            Token = authResult.Result.Content.ReadAsStringAsync().Result
        };
    }
}