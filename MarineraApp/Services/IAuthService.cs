using MarineraApp.ViewModels.Login;
using SharedEntities.Auth;

namespace MarineraApp.Services;

public interface IAuthService
{
    public Task<WebAuthenticatorResult> LoginWithGoogleAsync();
    public Task<AuthResponse> Login(LoginModel viewModel);
}