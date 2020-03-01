using System;
using System.Diagnostics.CodeAnalysis;

namespace Reservation.Domain
{
    public class 予約された会議室
    {
        // todo: この名前ヤバい
        private readonly MeetingRoom room;
        private readonly 予約期間 range;

        public 予約された会議室(MeetingRoom room, 予約期間 range)
        {
            this.room = room;
            this.range = range;
        }


        public bool かぶってますか(予約したい会議室 other) {
            var 会議室いっしょ = room.Equals(other.room);
            var 予約期間かぶり = range.かぶってますか(other.range);

            return 会議室いっしょ && 予約期間かぶり;
        }
        // todo: equalメソッド必要か
    }
}