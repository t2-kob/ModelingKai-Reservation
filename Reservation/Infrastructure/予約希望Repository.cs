
using Reservation.Domain;

namespace Infrastructure
{
    public class 予約希望Repository : I予約希望Repository
    {
        public void Save(MeetingRoom room, ReserverId id, 時間に関するなにがし range, 想定使用人数 ninzu)
        {
            throw new System.NotImplementedException();
        }

        public bool この会議室が予約可能かどうか教えて(MeetingRoom room, ReserverId id, 時間に関するなにがし range, 想定使用人数 ninzu)
        {
            // 1.仮実装とテスト
            // 2.ガチ実装
            return true;
        }
    }
}