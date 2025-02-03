namespace MarineraApp.Services;

public class SecureStorageService
{
    public async Task SetAsync(string key, string value)
    {
        await SecureStorage.SetAsync(key, value);
    }

    public async Task<string?> GetAsync(string key)
    {
        return await SecureStorage.GetAsync(key);
    }
}