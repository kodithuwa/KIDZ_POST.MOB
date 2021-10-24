using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.Bluetooth;
using Plugin.CurrentActivity;
using Android.Locations;
using Xamarin.Forms;
using Android.Content;
using Xamarin.Essentials;

namespace KIDZ_POST.MOB.Droid
{
    [Activity(Label = "KIDZ_POST.MOB", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static MainActivity CurrentActivity;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            //CheckDeviceLocation();
            //CurrentActivity = this;
        }



        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        internal static Activity GetActivity()
        {
            return MainActivity.CurrentActivity;
        }

        public void CheckDeviceLocation()
        {

            LocationManager locationManager = (LocationManager)Forms.Context.GetSystemService(Context.LocationService);
            if (locationManager.IsProviderEnabled(LocationManager.GpsProvider) == false)
            {
                AlertDialog.Builder builder = new AlertDialog.Builder(this);

                builder.SetTitle("Kidz Post requires your location");
                builder.SetMessage("Please enable location services from your settings");
                builder.SetPositiveButton("Settings", (c, ev) =>
                {
                    Intent gpsSettingIntent = new Intent(global::Android.Provider.Settings.ActionLocationSourceSettings);
                    Forms.Context.StartActivity(gpsSettingIntent);
                });
                builder.SetNegativeButton("Cancel", (s, e) =>
                {

                    //Toast.MakeText(Activity, "Cancelled!", ToastLength.Short).Show();
                });

                Dialog alertDialog = builder.Create();
                alertDialog.SetCanceledOnTouchOutside(false);
                alertDialog.Show();

            }



        }

    }
}