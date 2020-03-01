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
        // memo:InMemoryとして持ちたかった為に、クラスを定義した
        private List<予約済み> list = new List<予約済み>();
        
        public void Save(MeetingRoom room, ReserverId id, 予約期間 range, 想定使用人数 ninzu)
        // public void Save(予約 reserved)
        {
            list.Add(new 予約済み(room, range));
        }

        public bool この会議室は予約可能ですか(MeetingRoom room, ReserverId id, 予約期間 range, 想定使用人数 ninzu)
        {
            var other = new 予約希望(room, range);

            bool 被っている = list.Any(x => x.かぶってますか(other));
            bool 予約可能である = !被っている;

            return 予約可能である;
        }
    }
}