using Android.App;
using Android.Content.PM;
using Android.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiTwitterApp.Platforms.Android
{
    //[IntentFilter(new[] { AndroidX.Core.Content.IntentCompat.vir.Content.Intent.ActionView },
    //    Categories = new[] { AndroidX.Core.Content.IntentCompat.CategoryLeanbackLauncher Android.Content.Intent.CategoryDefault, Android.Content.Intent.CategoryBrowsable },
    //    DataScheme = "myapp")]
    [Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
    [IntentFilter(new[] { Intent.ActionView }, Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable }, DataScheme = "myapp")]
    public class WebAuthenticationCallbackActivity : Microsoft.Maui.Essentials.WebAuthenticatorCallbackActivity
    {
    }
}
