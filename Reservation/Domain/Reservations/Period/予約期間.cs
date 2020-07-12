using Reservation.Domain.Exceptions;
using System;

namespace Reservation.Domain.Reservations.Period {
    public class 予約期間 {

        private readonly 予約開始日時 _開始日時;
        private readonly 予約終了日時 _終了日時;

        public 予約年月日 予約年月日 => _開始日時.年月日;


        public 予約期間(予約開始日時 開始日時, 予約終了日時 終了日時) {
            if(!開始日時.同じ日ですか(終了日時.年月日))
                throw new ドメインエラーException(new ArgumentOutOfRangeException($"{nameof(同じ日ですか)}"));

            if (終了日時.AsDateTime() <= 開始日時.AsDateTime())
                throw new ドメインエラーException(new ArgumentOutOfRangeException($"開始日時よりも終了日時の方が同じか後です。"));

            _開始日時 = 開始日時;
            _終了日時 = 終了日時;

            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns>true:被っている false:被っていない</returns>
        public bool 時間かぶってますか(予約期間 other)
        {

            //TODO: 日付も比較されちゃうけど・・・
            //TODO: 時間が「かぶってる」ことよりも「かぶってない」ことを判定した方が簡単かもしれないですね。other.end < self.start(＝がいるかどうかはわからない。。。）
            bool 時間かぶってますか = (_開始日時.AsDateTime() >= other._開始日時.AsDateTime()
                                    && _開始日時.AsDateTime() < other._終了日時.AsDateTime()) ||
                                      (_開始日時.AsDateTime() <= other._開始日時.AsDateTime()
                                    && _終了日時.AsDateTime() > other._開始日時.AsDateTime());


            return 時間かぶってますか;
        }
        internal bool かぶってますか(予約期間 other)
        {
            return 時間かぶってますか(other);
        }
        public bool 同じ日ですか(予約年月日 予約年月日)
        {
            return _開始日時.同じ日ですか(予約年月日)
                || _終了日時.同じ日ですか(予約年月日);
        }


        public string 開始日時()
        {

            return _開始日時.AsDateTime().ToString("yyyy-MM-dd HH:mm"); //TODO: ss なしでもいける？？
        }

        public string 終了日時()
        {

            return _終了日時.AsDateTime().ToString("yyyy-MM-dd HH:mm"); //TODO: ss なしでもいける？？
        }
    }
}
