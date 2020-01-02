using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation {
    class ReservationUseCase {

        public 予約結果 Reserve(int year, int コマ数) { 
            var 予約する時必要な情報 = new 予約する時必要な情報(new MeetingRoom(),
                                                                new ReserverId(),
                                                                new 時間に関するなにがし(),
                                                                new 想定使用人数());

            var 予約結果 = 予約する時必要な情報.予約(); //todo

            return 予約結果;
        }
    }
}
