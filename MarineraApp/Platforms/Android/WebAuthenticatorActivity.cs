using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using MarineraApp.Constants;

namespace MarineraApp;

[Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop, Exported = true)]
[IntentFilter(new[] { Intent.ActionView },
    Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
    DataScheme = Constants.Constants.CallbackScheme)]
public class WebAuthenticatorActivity : WebAuthenticatorCallbackActivity
{
}