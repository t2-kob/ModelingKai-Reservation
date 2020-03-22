using System;
using System.Collections.Generic;
using System.Text;
using Reservation.Domain;
using Reservation.Domain.Reservations;
using Reservation.Domain.Reservations.MeetingRooms;
using Reservation.Domain.Reservations.Period;
using Reservation.Infrastructure;

namespace Reservation.Usecase {
    public class ReservationUseCase {

        private readonly I予約希望Repository repository;

        public ReservationUseCase(I予約希望Repository repository) {
            this.repository = repository;
        }


        //TODO: 返すのはプリミティブ？予約結果？　とりあえず一旦プリミティブで。
        public bool 予約する(MeetingRoom room, ReserverId reserverId, 予約期間 予約期間, 想定使用人数 想定使用人数) {

            //TODO: これはここで作るべき情報？
            var 予約希望 = new 予約希望(room, reserverId, 予約期間, 想定使用人数);


            予約済み群 予約希望日の予約の一覧 = repository.この日の予約一覧をください(予約希望.予約年月日);

            if (予約希望日の予約の一覧.かぶってますか(予約希望)) {
                return false;
            }

            repository.Save(予約希望);
            return true;
        }

        //public 予約結果 Reserve2(int year, int コマ数) { 
        //    var 予約希望 = 予約希望(4つの情報);

        //    var 完全予約 = 予約希望.申請();  

        //    return おBarちゃん.管理簿にちゃんと記録する(完全予約);
        //}

        //public 予約結果 Reserve3(int year, int コマ数) { 
        //    var 予約希望 = 予約希望(4つの情報);
        //    var 管理簿 = 管理簿();
        //    var 完全予約 = 予約希望.チェック(管理簿);
        //    return 管理簿.記録する(完全予約);
        //}
    }
}
