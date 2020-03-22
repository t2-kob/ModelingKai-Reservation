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
        // 予約済みはDomainの持ち物。全部リポジトリの中身をとってきて、
        // かぶってるかを確認する振る舞いをどこかに持たせる(ファーストクラスコレクション？)
        //   ==> Repository から、スマートなふるまい(かぶってる？) を排除する。


        // memo:InMemoryとして持ちたかった為に、クラスを定義した
        private List<予約済み> list = new List<予約済み>();
        
        public void Save(予約希望 きぼう)
        {
            list.Add(new 予約済み(きぼう.Room, きぼう.ReserverId, きぼう.Range, きぼう.想定使用人数_));
        }

        public 予約済み群 この日の予約一覧をください(予約年月日 予約年月日)
        {
            var 年月日が一致する予約の一覧 = list.Where(x => x.この日の予約ですか(予約年月日));
            return new 予約済み群(年月日が一致する予約の一覧);
        }
    }
}