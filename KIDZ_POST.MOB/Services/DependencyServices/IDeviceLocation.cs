//---------------------------------------------------------------------------------------
// <copyright file="IDeviceLocation.cs" company="Evicio (Pvt) Ltd.">
//  Copyright (c) Evicio (Pvt) Ltd. All rights reserved.
// </copyright>
//---------------------------------------------------------------------------------------

namespace KIDZ_POST.MOB.Services.DependencyServices
{
    public interface IDeviceLocation
    {
        bool LocationStatus();
        void CheckDeviceStatus();
    }
}
