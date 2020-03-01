using Reservation.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure
{
    /// <summary>
    /// インメモリでのリポジトリ
    /// </summary>
    public class 予約希望Repository : I予約希望Repository
    {
        private List<予約された会議室> list = new List<予約された会議室>();
        
        public void Save(MeetingRoom room, ReserverId id, 予約期間 range, 想定使用人数 ninzu)
        {
            list.Add(new 予約された会議室(room, range));
        }

        public bool この会議室は予約可能ですか(MeetingRoom room, ReserverId id, 予約期間 range, 想定使用人数 ninzu)
        {
            var other = new 予約したい会議室(room, range);

            bool 被っている = list.Any(x => x.かぶってますか(other));
            bool 予約可能である = !被っている;

            return 予約可能である;
        }
    }
}