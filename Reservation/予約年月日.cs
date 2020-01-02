using System;
using System.Collections.Generic;
using System.Text;

namespace Reservation {
    public class 予約年月日 {
        public int Year { get; }
        public int Month { get; }
        public int Day { get; }
        public void 予約年月日(int year, int month, int day) {
            this.Year = year;
            this.Month = month;
            this.Day = day;
        }
    }
}
