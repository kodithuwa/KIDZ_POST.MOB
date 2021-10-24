//---------------------------------------------------------------------------------------
// <copyright file="ISQLite.cs" company="Evicio (Pvt) Ltd.">
//  Copyright (c) Evicio (Pvt) Ltd. All rights reserved.
// </copyright>
//---------------------------------------------------------------------------------------

namespace eCiteLite.Data
{
    using SQLite;

    public interface ISQLite
    {
        SQLiteAsyncConnection GetConnection();
    }
}
