using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Reservation.Domain.Reservations;
using Reservation.Domain.Reservations.MeetingRooms;
using Reservation.Domain.Reservations.Period;

namespace SQLiteInfra
{

    public class SQLite予約希望Repository : I予約希望Repository
    {
        public void Save(予約希望 予約希望)
        {
            var sqlConnectionSb = new SQLiteConnectionStringBuilder { DataSource = "reserve.db" };

            using (var cn = new SQLiteConnection (sqlConnectionSb.ToString()))
            {
                cn.Open();

                using (var cmd = new SQLiteCommand(cn))
                {
                    string id = Guid.NewGuid().ToString();
                    cmd.CommandText = "Insert INTO reserve VALUES(" +
                        "@ID," +
                        "@ROOM_NAME," +
                        "@START_DATE_TIME," +
                        "@END_DATE_TIME)";

                    // if 予約希望.Room.AsString() == hogehoge みたいなこと書けるぜ
                    // if 予約希望.Room.ToString() これだと、なにが返ってくるかわからない？
                    // ToString()が返すなのかが、クラス名なのか、会議室名なのか、わかりづらい？？

                    cmd.Parameters.Add(new SQLiteParameter("@ID", id));
                    cmd.Parameters.Add(new SQLiteParameter("@ROOM_NAME", 予約希望.Room.DisplayName));
                    cmd.Parameters.Add(new SQLiteParameter("@START_DATE_TIME", 予約希望.Range.開始日時())); // 2020-05-20 10:00
                    cmd.Parameters.Add(new SQLiteParameter("@END_DATE_TIME", 予約希望.Range.終了日時())); // 2020-05-20 12:00
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public 予約済み群 この日の予約一覧をください(予約年月日 予約年月日)
        {
            var sqlConnectionSb = new SQLiteConnectionStringBuilder { DataSource = "reserve.db" };

            using (var cn = new SQLiteConnection (sqlConnectionSb.ToString()))
            {
                cn.Open();

                using (var cmd = new SQLiteCommand(cn))
                {
                    cmd.CommandText = "SELECT " + 
                        "id," +
                        "room_name, " +
                        "start_datetime, " +
                        "end_datetime " +
                        "FROM reserve " + 
                        "WHERE start_datetime >= datetime(@DATETIME1) AND start_datetime <= datetime(@DATETIME2)";

                    var dt1 = $"{予約年月日.Year.ToString()}-{予約年月日.Month.ToString("00")}-{予約年月日.Day.ToString("00")} 00:00:00.000";
                    var dt2 = $"{予約年月日.Year.ToString()}-{予約年月日.Month.ToString("00")}-{予約年月日.Day.ToString("00")} 23:59:59.999";
                    cmd.Parameters.Add(new SQLiteParameter("@DATETIME1", dt1));
                    cmd.Parameters.Add(new SQLiteParameter("@DATETIME2", dt2));

                    var reader = cmd.ExecuteReader();

                    var results = new List<予約済み>();
                    while (reader.Read())
                    {
                        var room_name = reader["room_name"].ToString(); // A
                        var start_datetime = reader["start_datetime"].ToString(); 
                        var end_datetime = reader["end_datetime"].ToString();

                        //2020-05-20 12:00
                        var sdt = DateTime.Parse(start_datetime); 
                        var 開始予約年月日 = new 予約年月日(sdt.Year, sdt.Month, sdt.Day);
                        
                        var edt = DateTime.Parse(end_datetime); 
                        var 終了予約年月日 = new 予約年月日(edt.Year, edt.Month, edt.Day);

                        var yoyaku = new 予約済み(new MeetingRoom(Enum.Parse<MeetingRoomName>(room_name)),
                                                new ReserverId(),
                                                new 予約期間(new 予約開始日時(開始予約年月日, (予約開始_時)sdt.Hour, (予約_分)sdt.Minute),
                                                            new 予約終了日時(終了予約年月日, (予約終了_時)edt.Hour, (予約_分)edt.Minute)),
                                                new 想定使用人数());

                        results.Add(yoyaku);

                    }
                    return new 予約済み群(results);
                }
            }
        }

        /// <summary>
        /// staticコンストラクタ
        /// 必ず呼ばれるので、こっちが良い
        /// </summary>
        static SQLite予約希望Repository()
        {
            var sqlConnectionSb = new SQLiteConnectionStringBuilder { DataSource = "reserve.db" };

            using (var cn = new SQLiteConnection (sqlConnectionSb.ToString()))
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

                    // cmd.CommandText = "Insert INTO reserve VALUES(" +
                    //     "2," +
                    //     "'RoomA'," +
                    //     "'2020-05-20 10:00'," +
                    //     "'2020-05-20 12:00')";

                    // cmd.ExecuteNonQuery();
                }
            }
        }
    }
}