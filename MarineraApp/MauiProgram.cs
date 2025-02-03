using MarineraApp.Pages.Login;
using MarineraApp.Services;
using MarineraApp.Templates.Controls;
using MarineraApp.ViewModels.Login;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using Microsoft.Maui.Controls.PlatformConfiguration;
using AuthService = MarineraApp.Services.AuthService;
using CommunityToolkit.Maui.Alerts;
using Microsoft.Extensions.Http; 

namespace MarineraApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("Urbanist-Regular.ttf", "UrbanistRegular");
                    fonts.AddFont("Urbanist-SemiBold.ttf", "UrbanistSemiBold");
                    fonts.AddFont("Urbanist-Bold.ttf", "UrbanistBold");
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .UseMauiCommunityToolkit();
            builder.Services.AddHttpClient("", httpClient =>
            {

            });
            builder.Configuration.AddInMemoryCollection(new Dictionary<string, string>
            {
                {"AndroidBaseUrl", "https://10.0.2.2:7047"},
                {"WindowsBaseUrl", "https://localhost:7047"}
            });
            //builder.Services.AddSingleton<AuthService>();

            builder.Services.AddTransient<HttpClient>();
            builder.Services.AddSingleton<SecureStorageService>();
            builder.Services.AddSingleton(WebAuthenticator.Default).AddSingleton(SecureStorage.Default);
            builder.Services.AddSingleton<IAuthService, AuthService>();
            builder.Services.AddTransient<LogIn>();
            builder.Services.AddTransient<LoginViewModel>();
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderlessEntry), (handler, view) =>
            {
#if ANDROID
                    handler.PlatformView.Background = null;
                    handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#endif
            });
#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}