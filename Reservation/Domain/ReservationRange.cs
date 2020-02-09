using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Domain {
    public class ReservationRange {
        private readonly 予約年月日 ReservationDate; // e.g. 2020年1月2日
        private readonly 予約開始時刻 jikoku; // e.g. 13:00
        private readonly コマ数 koma; // e.g. 12コマ(3時間)

        //todo: ビジネスルール：30日以内までしか予約できない

        public ReservationRange(予約年月日 ReservationDate, 予約開始時刻 jikoku, コマ数 koma)
        {
            //todo: ビジネスルール：10:00-19:00までしか予約が出来ない
            // 予約開始時刻とコマ数を見て、10:00-19:00までしか予約できないことを確認する

            //todo:
            // 1. このメソッドの中で、予約開始時刻のDateTimeとコマ数のDateTimeを貰って、
            // 計算をして、10:00-19:00以内だよね？ということを確認する
            // ↑DateTimeをおもらしするのは止めたほうが良さそう。

            // 2. ↑の計算を予約開始時刻クラスか、コマ数クラスの中に委譲する？

            // 3. ↑もしかしたら、それ専用のクラスを作るか？

            // 最終手段. コマ数をやめて、予約終了時刻を作るか？

            this.ReservationDate = ReservationDate;
            this.jikoku = jikoku;
            this.koma = koma;

        }
    }
}
