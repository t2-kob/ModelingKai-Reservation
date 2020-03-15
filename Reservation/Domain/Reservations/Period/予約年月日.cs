using System;
using System.Diagnostics.CodeAnalysis;

namespace Reservation.Domain.Reservations.Period {
    /// <summary>
    /// 年月日だけ持つ
    /// </summary>
    public class 予約年月日 : IEquatable<予約年月日> {
        private readonly int year;
        private readonly int month;
        private readonly int day;

        public 予約年月日(int year, int month, int day) 
        {
            this.year = year;
            this.month = month;
            this.day = day;
        }

        public string AsString()
        {
            // 値オブジェクトの特別感を出すために
            return $"{year}年{month}月{day}日";
        }

        public bool Equals([AllowNull] 予約年月日 other)
        {
            if (other == null)
            {
                return false;
            }

            return year == other.year &&
                   month == other.month &&
                   day == other.day;
        }
    }
}
