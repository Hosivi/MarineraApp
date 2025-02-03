using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace MarineraApp;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true,
    LaunchMode = LaunchMode.SingleTop,
    ConfigurationChanges = ConfigChanges.ScreenSize |
                           ConfigChanges.Orientation | ConfigChanges.UiMode |
                           ConfigChanges.ScreenLayout |
                           ConfigChanges.SmallestScreenSize |
                           ConfigChanges.Density, Exported = true)]
[IntentFilter(new[] { Intent.ActionView },
    Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
    DataScheme = "http",
    DataHost = "localhost",
    DataPathPrefix = "/myapp")]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnNewIntent(Intent intent)
    {
        base.OnNewIntent(intent);

        if (Intent.ActionView.Equals(intent.Action))
        {
            var uri = intent.Data;

            // Extract the authorization code from the URL
            var code = uri.GetQueryParameter("code");
        }
    }
}