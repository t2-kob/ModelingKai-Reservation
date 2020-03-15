using System.Collections.Generic;
using System.Linq;
using Reservation.Domain.Reservations;
using Reservation.Domain.Reservations.MeetingRooms;
using Reservation.Domain.Reservations.Period;

namespace Reservation.Infrastructure
{
    /// <summary>
    /// インメモリでのリポジトリ
    /// </summary>
    public class 予約希望Repository : I予約希望Repository
    {
        // memo:InMemoryとして持ちたかった為に、クラスを定義した
        private List<予約済み> list = new List<予約済み>();
        
        public void Save(予約希望 きぼう)
        // public void Save(予約 reserved)
        {
            list.Add(new 予約済み(きぼう.Room, きぼう.ReserverId, きぼう.Range, きぼう.想定使用人数_));
        }

        public bool この会議室は予約可能ですか(予約希望 きぼう)
        {
            bool 被っている = list.Any(x => x.かぶってますか(きぼう));
            bool 予約可能である = !被っている;

            return 予約可能である;
        }
    }
}