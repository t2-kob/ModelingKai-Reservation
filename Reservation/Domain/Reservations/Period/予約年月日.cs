using System;
using System.Diagnostics.CodeAnalysis;

namespace Reservation.Domain.Reservations.Period {
    /// <summary>
    /// 年月日だけ持つ
    /// </summary>
    public class 予約年月日 : IEquatable<予約年月日> {

        public int Year { get; }
        public int Month { get; }
        public int Day { get; }


        public 予約年月日(int year, int month, int day) 
        {
            this.Year = year;
            this.Month = month;
            this.Day = day;
        }



        public bool Equals([AllowNull] 予約年月日 other)
        {
            if (other == null)
            {
                return false;
            }

            return Year == other.Year &&
                   Month == other.Month &&
                   Day == other.Day;
        }
    }
}
