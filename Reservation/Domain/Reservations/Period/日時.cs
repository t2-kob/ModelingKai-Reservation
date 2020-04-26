using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Domain.Reservations.Period
{
    public class 日時
    {
        // TODO: 時・分はEnumのままにする？どうする？ ==> UT 終わってから考えよう。
        // TODO: そもそも DateTime 1つとかで持つべき？
        public 予約年月日 年月日 { get; }
        private readonly 予約開始_時 時;
        private readonly 予約開始_分 分;


        public 日時(予約年月日 年月日, 予約開始_時 時, 予約開始_分 分) {
            this.年月日 = 年月日;
            this.時 = 時;
            this.分 = 分;
        }

        internal bool 時間が予約範囲外である()
        {
            return (int)時 < 10 || ((int)時 == 19 && (int)分 > 0) || ((int)時 >= 20);
        }

        //public 日時(予約年月日 年月日, 予約開始_時 時, 予約開始_分 分)
        //{
        //    this.Value = new DateTime(xxxxxxx)
        //}
        //public 日時(予約年月日 年月日, 予約終了_時 時, 予約終了_分 分)
        //{
        //    this.Value = new DateTime(xxxxxxx)
        //}




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
