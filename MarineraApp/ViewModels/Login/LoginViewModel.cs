using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MarineraApp.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using MarineraApp.Constants;
using SharedEntities.Auth;
using CommunityToolkit.Maui.Alerts;

namespace MarineraApp.ViewModels.Login;

public class AuthCodeRequest
{
    public string Code { get; set; }
}

public partial class LoginViewModel : ObservableObject
{
    public LoginViewModel(ISecureStorage storage, IWebAuthenticator webAuthenticator, IAuthService authService)
    {
        _storage = storage;
        _webAuthenticator = webAuthenticator;
        _authService = authService;
    }

    private IAuthService _authService { get; }
    private ISecureStorage _storage { get; }
    private IWebAuthenticator _webAuthenticator { get; }
    public string Email { get; set; }

    public string Password { get; set; }

    [RelayCommand]
    public async Task LoginWithGoogle(string scheme)
    {
        var authorizationUrl = BuildGoogleAuthorizationUrl();
        await Browser.OpenAsync(authorizationUrl, BrowserLaunchMode.SystemPreferred);
        // try
        // {
        //     var result = await _webAuthenticator.AuthenticateAsync(new WebAuthenticatorOptions
        //     {
        //         CallbackUrl = new Uri($"{Constants.Constants.CallbackScheme}://"),
        //         Url = new Uri(new Uri(Constants.Constants.BaseUrl), $"mobileauth/signin{scheme}")
        //     });
        //
        //     await _storage.SetAsync("access_token", result.AccessToken);
        //
        // }
        // catch (Exception ex)
        // {
        //     Console.WriteLine("ex.Message");
        // }
    }

    [RelayCommand]
    public async Task Login()
    {
        var viewModel = new LoginModel() { Email = Email, Password = Password };
        var authResponse = await _authService.Login(viewModel);
        await Shell.Current.DisplayAlert("", authResponse.Token.ToString(), "ok");
    }

    private string BuildGoogleAuthorizationUrl()
    {
        var clientId =
            "182893144957-6s6g0n4k1eqrhf6hant4eogthg3l37rh.apps.googleusercontent.com";

        var redirectUri = "https://bd3a-38-25-122-99.ngrok-free.app/Auth/oauth2redirect";
        var scope = "https://www.googleapis.com/auth/userinfo.email";
        var state = Guid.NewGuid().ToString(); // Protege contra ataques CSRF

        return
            $"https://accounts.google.com/o/oauth2/auth?client_id={clientId}&redirect_uri={redirectUri}&response_type=code&scope={scope}&state={state}";
    }
}