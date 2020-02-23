using Reservation.Domain;
using System;
using System.Collections.Generic;

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

        public bool この会議室が予約可能かどうか教えて(MeetingRoom room, ReserverId id, 予約期間 range, 想定使用人数 ninzu)
        {

            // NG条件: 会議室名がバッティングしている かつ 時間がバッティングしている






            // 予約が不可能な状態とは？
            // いまの予約情報が取れなければいけなくて。
            

            // 予約したい会議室とある時間帯の組み合わせが、予約済のものと一致したら、予約できない。

            // 部分一致。

            // TODO: 会議室と時間の組み合わせ。←　1個のオブジェクト？

            // Aという会議室を、12:00-14:00借りたい。
            // 1. すでに誰かが、Aの会議室を13:00-16:00借りてたら、ダメーってなる。
            // 2. Aが14:00-16:00で借りてたらOK

            // 1.仮実装とテスト
            // 2.ガチ実装
            return true;
        }
    }
}