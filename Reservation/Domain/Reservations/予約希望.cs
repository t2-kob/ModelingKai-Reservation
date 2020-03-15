using Reservation.Domain.Reservations.MeetingRooms;
using Reservation.Domain.Reservations.Period;

namespace Reservation.Domain.Reservations
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