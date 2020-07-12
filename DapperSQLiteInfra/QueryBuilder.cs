using System;
using Reservation.Domain.Reservations;
using Reservation.Domain.Reservations.Period;
using QueryTemplate = System.String;
using QueryParameter = System.Object;

namespace DapperSQLiteInfra
{
    public class QueryBuilder
    {
        
        public static (QueryTemplate template, QueryParameter parameter) 指定された日の予約一覧を取得するクエリを生成する(予約年月日 予約年月日)
        {
            return (SelectReserveSql,
                new
                {
                    DateTimeFrom = $"{予約年月日.Year.ToString()}-{予約年月日.Month.ToString("00")}-{予約年月日.Day.ToString("00")} 00:00:00.000",
                    DateTimeTo = $"{予約年月日.Year.ToString()}-{予約年月日.Month.ToString("00")}-{予約年月日.Day.ToString("00")} 23:59:59.999",
                });
        }

        const string SelectReserveSql =
@"SELECT
  id,
  room_name, 
  start_datetime, 
  end_datetime 
FROM reserve 
WHERE start_datetime >= datetime(@DateTimeFrom) 
AND start_datetime <= datetime(@DateTimeTo)";

        
        public static (QueryTemplate template, QueryParameter parameter) 予約を保存するクエリを生成する(予約希望 予約希望)
        {
            var dapper予約希望 = new ReserveTableRow
            {
                Id = Guid.NewGuid().ToString(),
                RoomName = 予約希望.Room.DisplayName,
                StartDateTime = 予約希望.Range.開始日時(),
                EndDateTime = 予約希望.Range.終了日時()
            };

            return (InsertReserveSql,
                    dapper予約希望);
        }
        
        private const string InsertReserveSql =
@"Insert INTO reserve VALUES(
 @Id,
 @RoomName,
 @StartDateTime,
 @EndDateTime)";
        
    }
    
    
}