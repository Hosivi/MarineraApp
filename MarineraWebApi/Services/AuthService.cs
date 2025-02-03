using Domain.Entities;
using Infrastructure.Repositories;
using SharedEntities.Auth;

namespace MarineraWebApi.Services;

public class AuthService
{
    private readonly RepositoryAsync<Organization> _organizationRepositoryAsync;

    public AuthService(RepositoryAsync<Organization> organizationRepositoryAsync)
    {
        _organizationRepositoryAsync = organizationRepositoryAsync;
    }

    /// <summary>
    ///     Este método se movera al serviocio del sistema Multitenant
    /// </summary>
    /// <returns></returns>
    public async Task<Organization?> GetDefaultOrganization()
    {
        return await _organizationRepositoryAsync.FirstOrDefaultAsync();
    }

    public async Task<bool> LoginAsync(string email, string password)
    {
        var loginModel = new LoginModel
        {
            Email = email, Password = password
        };
        return false;
    }
}

public class TokenResponse
{
    public string Token { get; set; }
}