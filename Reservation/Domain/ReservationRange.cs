using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Domain {
    public class ReservationRange {
        private readonly 予約年月日 ReservationDate; // e.g. 2020年1月2日
        private readonly 予約開始時刻 jikoku; // e.g. 13:00
        private readonly コマ数 koma; // e.g. 12コマ(3時間)

        //todo: ビジネスルール：10:00-19:00までしか予約が出来ない
        //todo: ビジネスルール：使える時間の長さは15分単位
        //todo: ビジネスルール：30日以内までしか予約できない

        public ReservationRange(予約年月日 ReservationDate, 予約開始時刻 jikoku, コマ数 koma)
        {
            this.ReservationDate = ReservationDate;
            this.jikoku = jikoku;
            this.koma = koma;
        }
    }
}
