//---------------------------------------------------------------------------------------
// <copyright file="LocationServiceBinder.cs" company="Evicio (Pvt) Ltd.">
//  Copyright (c) Evicio (Pvt) Ltd. All rights reserved.
// </copyright>
//---------------------------------------------------------------------------------------

using Android.OS;

namespace KIDZ_POST.MOB.Droid.Services.Location
{
    public class LocationServiceBinder : Binder
    {
        public LocationService Service
        {
            get { return this.service; }
        }
        protected LocationService service;

        public bool IsBound { get; set; }

        // constructor
        public LocationServiceBinder(LocationService service)
        {
            this.service = service;
        }
    }
}