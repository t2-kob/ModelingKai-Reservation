using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Domain.Reservations.Period
{
    // TODO: 2020/4/26 とりあえず、日時を 開始日時と終了日時 に分けてみる。Enum(開始日時_時) もセットで考える。で、それを今の状態と比較してどうするか決める。

    public class 予約開始日時
    {
        // TODO: 時・分はEnumのままにする？どうする？ ==> UT 終わってから考えよう。
        // TODO: そもそも DateTime 1つとかで持つべき？
        public 予約年月日 年月日 { get; }
        private readonly 予約開始_時 時;
        private readonly 予約_分 分;
        // Enum 分ける
        // 予約開始_時分 と 予約終了_時分？ ==> 元の予約期間みたいに年月日+開始終了の時分
        // 


        public 予約開始日時(予約年月日 年月日, 予約開始_時 時, 予約_分 分) {
            this.年月日 = 年月日;
            this.時 = 時;
            this.分 = 分;
        }




        // 時間かぶっているかどうかを比較したい。

        public DateTime AsDateTime() { 
            return new DateTime(年月日.Year, 年月日.Month, 年月日.Day, (int)時, (int)分, 0);
        }

        internal bool 同じ日ですか(予約年月日 予約年月日)
        {
            return 年月日.Equals(予約年月日);
        }
    }
}
