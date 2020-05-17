using System.Data.SQLite;
using Reservation.Domain.Reservations;
using Reservation.Domain.Reservations.Period;

namespace SQLiteInfra
{

    public class SQLite予約希望Repository : I予約希望Repository
    {
        public void Save (予約希望 予約希望)
        {

            throw new System.NotImplementedException ();
        }

        public 予約済み群 この日の予約一覧をください(予約年月日 予約年月日)
        {
            throw new System.NotImplementedException ();
        }

        /// <summary>
        /// staticコンストラクタ
        /// 必ず呼ばれるので、こっちが良い
        /// </summary>
        static SQLite予約希望Repository ()
        {
            var sqlConnectionSb = new SQLiteConnectionStringBuilder { DataSource = "reserve.db" };

            using (var cn = new SQLiteConnection (sqlConnectionSb.ToString ()))
            {
                cn.Open ();

                using (var cmd = new SQLiteCommand (cn))
                {
                    // テーブル作成
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS reserve(" +
                        "id INTEGER NOT NULL PRIMARY KEY," + // 
                        "room_name TEXT NOT NULL," +
                        "start_datetime DATE NOT NULL," + // 2020-05-20 10:00
                        "end_datetime DATE NOT NULL)"; // 2020-05-20 13:00

                    cmd.ExecuteNonQuery ();

                    cmd.CommandText = "Insert INTO reserve VALUES(" +
                        "1," +
                        "RoomA" +
                        "2020-05-20 10:00" +
                        "2020-05-20 12:00)";

                    cmd.ExecuteNonQuery ();
                }
            }
        }
    }
}