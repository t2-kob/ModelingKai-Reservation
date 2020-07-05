using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Reservation.Domain.Reservations;
using Reservation.Domain.Reservations.MeetingRooms;
using Reservation.Domain.Reservations.Period;
using Dapper;
using System.Text;
using QueryTemplate = System.String;
using QueryParameter = System.Object;

namespace DapperSQLiteInfra
{


    public class DapperSQLite予約希望Repository : I予約希望Repository
    {
        const string DB_FILE_NAME = "reserve.db";

        public void Save(予約希望 予約希望)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            
            var queryWithParameter = QueryBuilder.予約を保存するクエリを生成する(予約希望);
            
            DBにSaveする(queryWithParameter.template,
                        queryWithParameter.parameter,
                        DB_FILE_NAME);
        }

        private void DBにSaveする(string template, object parameter, string dbFileName)
        {
            var sqlConnectionSb = new SQLiteConnectionStringBuilder { DataSource = dbFileName };

            using var cn = new SQLiteConnection(sqlConnectionSb.ToString());
            cn.Open();
            cn.Execute(template, parameter);
        }

        public 予約済み群 この日の予約一覧をください(予約年月日 予約年月日)
        {
            var queryWithParameter = QueryBuilder.指定された日の予約一覧を取得するクエリを生成する(予約年月日);

            var data = DBから予約の一覧を取ってくる(queryWithParameter.template,
                                                    queryWithParameter.parameter,
                                                    DB_FILE_NAME);

            return ドメインオブジェクトに変換する(data);
        }
        
        private IEnumerable<ReserveTableRow> DBから予約の一覧を取ってくる(QueryTemplate template, QueryParameter parameter, string dataSource)
        {
            var sqlConnectionSb = new SQLiteConnectionStringBuilder { DataSource = dataSource };
            using var cn = new SQLiteConnection(sqlConnectionSb.ToString());

            cn.Open();
            return cn.Query<ReserveTableRow>(template, parameter);
        }


        private 予約済み群 ドメインオブジェクトに変換する(IEnumerable<ReserveTableRow> rows)
        {
            return new 予約済み群(rows.Select(ドメインオブジェクトに変換する));
        }

        private 予約済み ドメインオブジェクトに変換する(ReserveTableRow row)
        {
            var sdt = DateTime.Parse(row.StartDateTime);
            var 開始予約年月日 = new 予約年月日(sdt.Year, sdt.Month, sdt.Day);

            var edt = DateTime.Parse(row.EndDateTime);
            var 終了予約年月日 = new 予約年月日(edt.Year, edt.Month, edt.Day);

            return new 予約済み(
                new MeetingRoom(Enum.Parse<MeetingRoomName>(row.RoomName)),
                new ReserverId(), 
                new 予約期間(
                    new 予約開始日時(開始予約年月日, (予約開始_時)sdt.Hour, (予約_分)sdt.Minute),
                    new 予約終了日時(終了予約年月日, (予約終了_時)edt.Hour, (予約_分)edt.Minute)),
                new 想定使用人数());
        }
    }
}