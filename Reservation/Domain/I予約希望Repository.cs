namespace Reservation.Domain
{
    public interface I予約希望Repository
    {
        void Save(MeetingRoom room,
                    ReserverId id,
                    予約期間 range,
                    想定使用人数 ninzu);
        // TODO:エンティティは知ってていいか？
        // TODO:値オブジェクトならワンチャン
        
        // masuda派はFind派
        bool この会議室が予約可能かどうか教えて(MeetingRoom room,
                        ReserverId id,
                        予約期間 range,
                        想定使用人数 ninzu);
        // リポジトリは、ドメインがやりたいことを実現する？
        // やりたいことをセーブ？　
    }
}