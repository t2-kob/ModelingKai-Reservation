using System;
using System.Collections.Generic;
using System.Text;
using Reservation.Domain;

namespace Reservation.Usecase {
    class ReservationUseCase {
        public bool Reserve(int year, int コマ数) {

            // TODO:ここのユースケースを書く&テストを書く


            // var 予約希望 = new 予約希望(new MeetingRoom(MeetingRoomName.A),
            //                         new ReserverId(),
            //                         new 予約期間(null, 予約開始_時._10, 予約開始_分._00, null),
            //                         new 想定使用人数());
            // var 予約結果 = 予約希望.申請(); 

            //TODO: 返すのはプリミティブ？予約結果？　とりあえず一旦プリミティブで。
            return false;
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
