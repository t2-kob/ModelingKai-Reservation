using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Domain {
    public class 予約期間 {
        private readonly 予約年月日 ReservationDate; // e.g. 2020年1月2日
        private readonly 予約開始_時 予約開始_時; // e.g. 13(時)
        private readonly 予約開始_分 予約開始_分; // e.g. 15(分)
        private readonly コマ数 koma; // e.g. 12コマ

        public 予約期間(予約年月日 ReservationDate, 予約開始_時 予約開始_時, 予約開始_分 予約開始_分, コマ数 予約コマ数)
        {
            //todo: ビジネスルール：10:00-19:00までしか予約が出来ない
            // 予約開始時刻とコマ数を見て、10:00-19:00までしか予約できないことを確認する
            var 残コマ数 = コマ数.残コマ数を教えて(予約開始_時,予約開始_分);
            if (! (残コマ数 >= 予約コマ数) )
                throw new ArgumentException($"{残コマ数}を超えることはできません");

            //todo:
            // 1. このメソッドの中で、予約開始時刻のDateTimeとコマ数のDateTimeを貰って、
            // 計算をして、10:00-19:00以内だよね？ということを確認する
            // ↑DateTimeをおもらしするのは止めたほうが良さそう。
            //
            //   1-1: Range が終了時刻を判断する (from 予約開始時刻、コマ数)

            // 予約開始_時と予約開始_分を渡して、残コマ数が取れる。それを比較する。

            // 2. ↑の計算を予約開始時刻クラスか、コマ数クラスの中に委譲する？
            //   2-1: 予約開始時刻が最大コマ数とかをくれる？

            // 3. ↑もしかしたら、それ専用のクラスを作るか？

            // 最終手段. コマ数をやめて、予約終了時刻を作るか？

            this.ReservationDate = ReservationDate;
            this.予約開始_時 = 予約開始_時;
            this.予約開始_分 = 予約開始_分;
            this.koma = 予約コマ数;
        }


        private DateTime 開始時刻は何時ですか()
        {
            // TODO: 1900年直指定ってどうよ？
            var result = new DateTime(1900, 1, 1, (int)予約開始_時, (int)予約開始_分, 0);
            return result;

        }
        private DateTime 終了時刻は何時ですか() {
            var 開始時刻 = 開始時刻は何時ですか();
            var 終了時刻 = 開始時刻.AddMinutes(koma.分換算());
            return 終了時刻;
        }

        public bool 時間かぶってますか(予約期間 other) {
            //開始時間とコマ数
            bool 時間かぶってますか = (開始時刻は何時ですか() >= other.開始時刻は何時ですか() 
                                && 開始時刻は何時ですか() < other.終了時刻は何時ですか()) ||
                             (開始時刻は何時ですか() <= other.開始時刻は何時ですか()
                                && 終了時刻は何時ですか() > other.開始時刻は何時ですか());

            return 時間かぶってますか;
        }


        internal bool かぶってますか(予約期間 other)
        {
            // 年月日ちがったらダメー
                return false;
            if (!ReservationDate.Equals(other)) {
            }



            return 時間かぶってますか(other);
        }

        //todo: ビジネスルール：30日以内までしか予約できない

        // TODO:開始時刻とコマ数の組み合わせで、ちゃんと10:00-19:00の範囲で収まるかどうかを調べたい
        // TODO:開始時刻とコマ数の組み合わせで、終了時刻って実際何時なのか？
        // ↑これいつ必要？

    }
}
