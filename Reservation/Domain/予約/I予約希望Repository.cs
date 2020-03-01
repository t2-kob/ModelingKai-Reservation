using Reservation.Domain.予約.会議室;
using Reservation.Domain.予約.期間;

namespace Reservation.Domain.予約
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
        bool この会議室は予約可能ですか(MeetingRoom room,
                        ReserverId id,
                        予約期間 range,
                        想定使用人数 ninzu);
        // リポジトリは、ドメインがやりたいことを実現する？
        // やりたいことをセーブ？　
    }
}