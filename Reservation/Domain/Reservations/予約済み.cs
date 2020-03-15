using Reservation.Domain.Reservations.MeetingRooms;
using Reservation.Domain.Reservations.Period;

namespace Reservation.Domain.Reservations
{
    public class 予約済み
    {
        // todo: この名前ヤバい
        // これ、DTOっぽい。
        // Repository的な責務っぽい
        private readonly MeetingRoom room;
        private readonly 予約期間 range;

        public 予約済み(MeetingRoom room, 予約期間 range)
        {
            this.room = room;
            this.range = range;
        }


        public bool かぶってますか(予約希望 other) {
            var 会議室いっしょ = room.Equals(other.room);
            var 予約期間かぶり = range.かぶってますか(other.range);

            return 会議室いっしょ && 予約期間かぶり;
        }
        // todo: equalメソッド必要か
    }
}