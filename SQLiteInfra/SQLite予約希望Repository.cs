using System;
using System.Data.SQLite;
using Reservation.Domain.Reservations;
using Reservation.Domain.Reservations.Period;

namespace SQLiteInfra
{

    public class SQLite予約希望Repository : I予約希望Repository
    {
        public void Save (予約希望 予約希望)
        {
            var sqlConnectionSb = new SQLiteConnectionStringBuilder { DataSource = "reserve.db" };

            using (var cn = new SQLiteConnection (sqlConnectionSb.ToString ()))
            {
                cn.Open ();

                予約希望.
                using (var cmd = new SQLiteCommand (cn))
                {
                    string id = Guid.NewGuid ().ToString ();
                    cmd.CommandText = "Insert INTO reserve VALUES(" +
                        "@ID," +
                        "@ROOM_NAME," +
                        "@START_DATE_TIME," +
                        "@END_DATE_TIME)";

                    // if 予約希望.Room.AsString() == hogehoge みたいなこと書けるぜ
                    // if 予約希望.Room.ToString() これだと、なにが返ってくるかわからない？
                    // ToString()が返すなのかが、クラス名なのか、会議室名なのか、わかりづらい？？

                    // String 
                    cmd.Parameters.Add (new SQLiteParameter ("@ID", id));
                    cmd.Parameters.Add (new SQLiteParameter ("@ROOM_NAME", 予約希望.Room.DisplayName));
                    cmd.Parameters.Add (new SQLiteParameter ("@START_DATE_TIME", 予約希望.Range.開始日時)); // 2020-05-20 10:00
                    cmd.Parameters.Add (new SQLiteParameter ("@END_DATE_TIME", 予約希望.Range.終了日時)); // 2020-05-20 12:00
                    cmd.ExecuteNonQuery ();
                }
            }
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
                        "id TEXT NOT NULL PRIMARY KEY," + // 
                        "room_name TEXT NOT NULL," +
                        "start_datetime DATE NOT NULL," + // 2020-05-20 10:00
                        "end_datetime DATE NOT NULL)"; // 2020-05-20 13:00

                    cmd.ExecuteNonQuery ();

                    // cmd.CommandText = "Insert INTO reserve VALUES(" +
                    //     "2," +
                    //     "'RoomA'," +
                    //     "'2020-05-20 10:00'," +
                    //     "'2020-05-20 12:00')";

                    // cmd.ExecuteNonQuery ();
                }
            }
        }
    }
}