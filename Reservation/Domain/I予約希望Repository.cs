

namespace Reservation.Domain
{
    public interface I予約希望Repository
    {
        void Save(MeetingRoom room,
                    ReserverId id,
                    時間に関するなにがし range,
                    想定使用人数 ninzu);
        // TODO:エンティティは知ってていいか？
        // TODO:値オブジェクトならワンチャン
        bool 空きを確認する(MeetingRoom room,
                        ReserverId id,
                        時間に関するなにがし range,
                        想定使用人数 ninzu);
        // リポジトリは、ドメインがやりたいことを実現する？
        // やりたいことをセーブ？　
    }
}