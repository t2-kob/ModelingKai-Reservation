using System;
using Reservation.Domain.Reservations.Period;

namespace Cui
{
    public static class 予約時間Parser
    {
        public static 予約終了日時 予約終了日時をつくる(DateTime input)
        {
            var 予約終了年月日 = new 予約年月日(input.Year, input.Month, input.Day);
            var 予約終了時 = (予約終了_時)Enum.Parse(typeof(予約終了_時), input.Hour.ToString());
            var 予約終了分 = (予約_分)Enum.Parse(typeof(予約_分), input.Minute.ToString());
            return new 予約終了日時(予約終了年月日, 予約終了時, 予約終了分);
        }

        public static 予約開始日時 予約開始日時をつくる(DateTime input)
        {
            var 予約開始年月日 = new 予約年月日(input.Year, input.Month, input.Day);
            var 予約開始時 = (予約開始_時)Enum.Parse(typeof(予約開始_時), input.Hour.ToString());
            var 予約開始分 = (予約_分)Enum.Parse(typeof(予約_分), input.Minute.ToString());
            return new 予約開始日時(予約開始年月日, 予約開始時, 予約開始分);
        }
    }
}
