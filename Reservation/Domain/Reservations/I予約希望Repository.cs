using Reservation.Domain.Reservations.MeetingRooms;
using Reservation.Domain.Reservations.Period;

namespace Reservation.Domain.Reservations
{
    public interface I予約希望Repository
    {
        void Save(予約希望 予約希望);
        // TODO:エンティティは知ってていいか？
        // TODO:値オブジェクトならワンチャン
        
        // masuda派はFind派
        bool この会議室は予約可能ですか(予約希望 予約希望);
        // リポジトリは、ドメインがやりたいことを実現する？
        // やりたいことをセーブ？　
    }
}