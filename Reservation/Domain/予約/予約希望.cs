using System;
using System.Diagnostics.CodeAnalysis;

namespace Reservation.Domain
{
    public class 予約希望
    {
        // todo: この名前ヤバい
        public readonly MeetingRoom room;
        public readonly 予約期間 range;

        public 予約希望(MeetingRoom room, 予約期間 range)
        {
            this.room = room;
            this.range = range;
        }
    }
}