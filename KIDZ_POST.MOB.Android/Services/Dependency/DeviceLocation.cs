//---------------------------------------------------------------------------------------
// <copyright file="DeviceLocation.cs" company="Evicio (Pvt) Ltd.">
//  Copyright (c) Evicio (Pvt) Ltd. All rights reserved.
// </copyright>
//---------------------------------------------------------------------------------------

using System;
using Android.App;
using Android.Content;
using Android.Locations;
using KIDZ_POST.MOB.Droid.Services.Dependency;
using KIDZ_POST.MOB.Droid;
using KIDZ_POST.MOB.Services.DependencyServices;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(DeviceLocation))]
namespace KIDZ_POST.MOB.Droid.Services.Dependency
{
    public class DeviceLocation : IDeviceLocation
    {
        public void CheckDeviceStatus()
        {
            LocationManager locationManager = (LocationManager)Forms.Context.GetSystemService(Context.LocationService);
            if (locationManager.IsProviderEnabled(LocationManager.GpsProvider) == false)
            {
                AlertDialog.Builder builder = new AlertDialog.Builder(MainActivity.CurrentActivity);

                builder.SetTitle("eCite Lite requires your location");
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

        public bool LocationStatus()
        {
            throw new NotImplementedException();
        }
    }
}