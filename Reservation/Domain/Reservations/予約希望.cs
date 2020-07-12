using Reservation.Domain.Reservations.MeetingRooms;
using Reservation.Domain.Reservations.Period;

namespace Reservation.Domain.Reservations
{
    public class 予約希望
    {
        private readonly MeetingRoom room;
        private readonly ReserverId reserverId;
        private readonly 予約期間 range;
        private readonly 想定使用人数 想定使用人数;

        public 予約希望(MeetingRoom room, ReserverId reserverId, 予約期間 range, 想定使用人数 想定使用人数)
        {
            // TODO:「ルール5: 会議室を予約できるのは、使用したい日の30日前(休日も込み)とする。時間帯は関係なし」
            //    ===> 期間外だったらそもそも「不正な予約希望」とする。そもそも作らせない(Exception)
            // 


            this.room = room;
            this.range = range;
            this.想定使用人数 = 想定使用人数;
            this.reserverId = reserverId;
        }

        public MeetingRoom Room => room;
        public 予約期間 Range => range;
        public 予約年月日 予約年月日 => Range.予約年月日;

        public ReserverId ReserverId => reserverId;
        public 想定使用人数 想定使用人数_ => this.想定使用人数;

    }
}