//---------------------------------------------------------------------------------------
// <copyright file="eCiteLitDatabase.cs" company="Evicio (Pvt) Ltd.">
//  Copyright (c) Evicio (Pvt) Ltd. All rights reserved.
// </copyright>
//---------------------------------------------------------------------------------------

namespace KIDZ_POST.Data
{
    using SQLite;
    using DO = MOB.Models;

    public class KidsPostDatabase
    {
        private readonly SQLiteAsyncConnection _connection;
        public KidsPostDatabase(string dbPath)
        {            
            _connection = new SQLiteAsyncConnection(dbPath);

            // Percs
            _connection.CreateTableAsync<DO.Message>().Wait();

        }
    }
}
