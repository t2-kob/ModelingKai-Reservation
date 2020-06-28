using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Reservation.Domain.Reservations;
using Reservation.Domain.Reservations.MeetingRooms;
using Reservation.Domain.Reservations.Period;
using Dapper;

namespace DapperSQLiteInfra
{
    public class DapperSQLite予約希望Repository : I予約希望Repository
    {
        public void Save(予約希望 予約希望)
        {

            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;


            string id = Guid.NewGuid().ToString();
            var dapper予約希望 = new Dapper予約希望
            {
                Id = id,
                RoomName = 予約希望.Room.DisplayName,
                StartDateTime = 予約希望.Range.開始日時(),
                EndDateTime = 予約希望.Range.終了日時()
            };


            var sqlConnectionSb = new SQLiteConnectionStringBuilder { DataSource = "reserve.db" };
            using (var cn = new SQLiteConnection(sqlConnectionSb.ToString()))
            {

                var sql = "Insert INTO reserve VALUES(" +
                                "@Id," +
                                "@RoomName," +
                                "@StartDateTime," +
                                "@EndDateTime)";

                cn.Open();
                var insertedRowCount = cn.Execute(sql, dapper予約希望);
            }
        }

        public 予約済み群 この日の予約一覧をください(予約年月日 予約年月日)
        {
            var dapper予約希望 = new Dapper予約希望
            {
                StartDateTime =  $"{予約年月日.Year.ToString()}-{予約年月日.Month.ToString("00")}-{予約年月日.Day.ToString("00")} 00:00:00.000",
                EndDateTime =  $"{予約年月日.Year.ToString()}-{予約年月日.Month.ToString("00")}-{予約年月日.Day.ToString("00")} 23:59:59.999",
            };
            
            

            var sqlConnectionSb = new SQLiteConnectionStringBuilder { DataSource = "reserve.db" };
            using (var cn = new SQLiteConnection(sqlConnectionSb.ToString()))
            {

                var sql =  "SELECT " +
                           "id," +
                           "room_name, " +
                           "start_datetime, " +
                           "end_datetime " +
                           "FROM reserve " +
                           "WHERE start_datetime >= datetime(@DateTimeFrom) AND start_datetime <= datetime(@DateTimeTo)";

                cn.Open();
                var result  = cn.Query<Dapper予約希望>(sql, new
                {
                    DateTimeFrom = $"{予約年月日.Year.ToString()}-{予約年月日.Month.ToString("00")}-{予約年月日.Day.ToString("00")} 00:00:00.000",
                    DateTimeTo = $"{予約年月日.Year.ToString()}-{予約年月日.Month.ToString("00")}-{予約年月日.Day.ToString("00")} 23:59:59.999",
                });

                
                var results = result.Select(x =>
                {
                    var sdt = DateTime.Parse(x.StartDateTime);
                    var 開始予約年月日 = new 予約年月日(sdt.Year, sdt.Month, sdt.Day);

                    var edt = DateTime.Parse(x.EndDateTime);
                    var 終了予約年月日 = new 予約年月日(edt.Year, edt.Month, edt.Day);

                    return new 予約済み(new MeetingRoom(Enum.Parse<MeetingRoomName>(x.RoomName)),
                        new ReserverId(),
                        new 予約期間(new 予約開始日時(開始予約年月日, (予約開始_時) sdt.Hour, (予約_分) sdt.Minute),
                            new 予約終了日時(終了予約年月日, (予約終了_時) edt.Hour, (予約_分) edt.Minute)),
                        new 想定使用人数());
                });
                
                return new 予約済み群(results);

            }
        }
    }
}