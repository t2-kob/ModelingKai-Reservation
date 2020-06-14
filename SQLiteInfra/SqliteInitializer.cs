using Reservation.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace SQLiteInfra
{
    public class SqliteInitializer : IDataStoreIntitalizer
    {
        public void CreateDataStore() {
            var sqlConnectionSb = new SQLiteConnectionStringBuilder { DataSource = "reserve.db" };

            using (var cn = new SQLiteConnection(sqlConnectionSb.ToString()))
            {
                cn.Open();

                using (var cmd = new SQLiteCommand(cn))
                {
                    // テーブル作成
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS reserve(" +
                        "id TEXT NOT NULL PRIMARY KEY," + // 
                        "room_name TEXT NOT NULL," +
                        "start_datetime DATE NOT NULL," + // 2020-05-20 10:00
                        "end_datetime DATE NOT NULL)"; // 2020-05-20 13:00

                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
