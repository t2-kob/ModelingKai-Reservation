using Reservation.Domain.Reservations.MeetingRooms;
using Reservation.Domain.Reservations.Period;

namespace Reservation.Domain.Reservations
{
    public class 予約済み
    {
        // todo: この名前ヤバい
        // これ、DTOっぽい。Repository的な責務っぽい
        private readonly MeetingRoom room;
        private readonly ReserverId reserverId;
        private readonly 予約期間 range;
        private readonly 想定使用人数 想定使用人数;

        public 予約済み(MeetingRoom room, ReserverId reserverId, 予約期間 range, 想定使用人数 想定使用人数)
        {
            this.room = room;
            this.reserverId = reserverId;
            this.range = range;
            this.想定使用人数 = 想定使用人数;
        }

        public bool この日の予約ですか(予約年月日 予約年月日) {
            return range.同じ日ですか(予約年月日);
        }


        public bool かぶってますか(予約希望 other) {
            var 会議室いっしょ = room.Equals(other.Room);
            var 予約期間かぶり = range.かぶってますか(other.Range);

            return 会議室いっしょ && 予約期間かぶり;
        }
        // todo: equalメソッド必要か
    }
}