namespace Reservation.Domain
{
    public class 予約された会議室
    {
        // todo: この名前ヤバい
        private readonly MeetingRoom room;
        private readonly ReservationRange range;

        public 予約された会議室(MeetingRoom room, ReservationRange range)
        {
            this.room = room;
            this.range = range;
        }

        // todo: equalメソッド必要か
    }
}