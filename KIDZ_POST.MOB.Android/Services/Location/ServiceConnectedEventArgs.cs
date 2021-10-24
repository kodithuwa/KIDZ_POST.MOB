//---------------------------------------------------------------------------------------
// <copyright file="ServiceConnectedEventArgs.cs" company="Evicio (Pvt) Ltd.">
//  Copyright (c) Evicio (Pvt) Ltd. All rights reserved.
// </copyright>
//---------------------------------------------------------------------------------------

using System;
using Android.OS;

namespace KIDZ_POST.MOB.Droid.Services.Location
{
    public class ServiceConnectedEventArgs : EventArgs
    {
        public IBinder Binder { get; set; }
    }
}