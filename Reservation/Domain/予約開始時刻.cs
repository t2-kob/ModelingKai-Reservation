namespace Reservation.Domain {
    /// <summary>
    /// hh:mmだけ持つ
    /// </summary>
    public class 予約開始時刻 {
        //todo: ビジネスルール：使える時間の長さは15分単位
        予約開始_時 hour;
        予約開始_分 minutes;

        public 予約開始時刻(予約開始_時 hour, 予約開始_分 minutes)
        {
            this.hour = hour;
            this.minutes = minutes;
        }

        // public DateTime 予約開始時刻を教えて()
        // {
        //     // ここで返すことは、予約開始_時と予約開始_分を
        //     return null;
        // }
    }
}