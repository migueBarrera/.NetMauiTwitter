using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using Microsoft.Maui;


namespace MauiTwitterApp
{
	[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
	public class MainActivity : MauiAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			Microsoft.Maui.Essentials.Platform.Init(this, bundle);
			Microsoft.Maui.Essentials.Platform.ActivityStateChanged += Platform_ActivityStateChanged;
		}

		protected override void OnResume()
		{
			base.OnResume();

			Microsoft.Maui.Essentials.Platform.OnResume(this);
		}

		protected override void OnNewIntent(Intent intent)
		{
			base.OnNewIntent(intent);

			Microsoft.Maui.Essentials.Platform.OnNewIntent(intent);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();

			//Microsoft.Maui.Essentials.Platform.ActivityStateChanged -= Platform_ActivityStateChanged;
		}

		void Platform_ActivityStateChanged(object sender, Microsoft.Maui.Essentials.ActivityStateChangedEventArgs e) =>
			Toast.MakeText(this, e.State.ToString(), ToastLength.Short).Show();

		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
		{
			Microsoft.Maui.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

			base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		}
	}
}