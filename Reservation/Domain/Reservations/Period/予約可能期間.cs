using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation.Domain.Reservations.Period
{

    /// <summary>
    /// 「ルール5: 会議室を予約できるのは、使用したい日の30日前(休日も込み)とする。時間帯は関係なし」 
    /// をなんとかするクラス。
    /// </summary>
    internal class 予約可能期間
    {
        private readonly 予約申込日 _予約申込日;

        public 予約可能期間(予約申込日 予約申込日) {
            _予約申込日 = 予約申込日;
        }


        public bool 全部含まれますか(予約期間 期間)
        {
            // 予約申し込み日から30日の期間をつくる

            // その期間に、予約期間が含まれるか？ ==> Yes/No.
        }
    }

    internal class 予約申込日
    {
        public int Year { get; }
        public int Month { get; }
        public int Day { get; }


        public 予約申込日(int year, int month, int day)
        {
            this.Year = year;
            this.Month = month;
            this.Day = day;
        }
    }
}
