using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Domain {
    public class 予約期間 {
        private const int コマあたりの分数 = 15;

        private readonly 予約年月日 ReservationDate; // e.g. 2020年1月2日
        private readonly 予約開始_時 予約開始_時; // e.g. 13(時)
        private readonly 予約開始_分 予約開始_分; // e.g. 15(分)
        private readonly コマ数 koma; // e.g. 12コマ



        public 予約期間(予約年月日 ReservationDate, 予約開始_時 予約開始_時, 予約開始_分 予約開始_分, コマ数 koma)
        {
            //todo: ビジネスルール：10:00-19:00までしか予約が出来ない
            // 予約開始時刻とコマ数を見て、10:00-19:00までしか予約できないことを確認する

            //todo:
            // 1. このメソッドの中で、予約開始時刻のDateTimeとコマ数のDateTimeを貰って、
            // 計算をして、10:00-19:00以内だよね？ということを確認する
            // ↑DateTimeをおもらしするのは止めたほうが良さそう。
            //
            //   1-1: Range が終了時刻を判断する (from 予約開始時刻、コマ数)

            // 2. ↑の計算を予約開始時刻クラスか、コマ数クラスの中に委譲する？
            //   2-1: 予約開始時刻が最大コマ数とかをくれる？



            // 3. ↑もしかしたら、それ専用のクラスを作るか？

            // 最終手段. コマ数をやめて、予約終了時刻を作るか？

            this.ReservationDate = ReservationDate;
            this.予約開始_時 = 予約開始_時;
            this.予約開始_分 = 予約開始_分;
            this.koma = koma;
        }

        // 
        // 何時から何時？
        // 

        //todo: ビジネスルール：30日以内までしか予約できない
        private 終了時間 なんじにおわりますか(予約開始_時 開始時, 予約開始_分 開始分, コマ数 コマ数)
        {


            // ドメインサービスでやるべきこと？
        }
    }
}
