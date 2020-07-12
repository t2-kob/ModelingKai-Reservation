using Reservation.Domain.Reservations.MeetingRooms;
using Reservation.Domain.Reservations.Period;

namespace Reservation.Domain.Reservations
{
    public interface I予約希望Repository
    {
        void Save(予約希望 予約希望);
        // TODO:エンティティは知ってていいか？
        // TODO:値オブジェクトならワンチャン

        
        予約済み群 この日の予約一覧をください(予約年月日 予約年月日);
        // リポジトリは、ドメインがやりたいことを実現する？
        // やりたいことをセーブ？　
    }
}