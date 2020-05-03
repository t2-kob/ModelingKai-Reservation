using System;

namespace Reservation.Domain.Reservations.Period {
    public class 予約期間 {

        //TODO: ルール: 日をまたいではいけない　とかあるよ。
        //TODO: 開始終了がひっくり返ってるとかはチェックできてない。


        private readonly 予約開始日時 _開始日時;
        private readonly 予約終了日時 _終了日時;

        public 予約年月日 予約年月日 => _開始日時.年月日;


        public 予約期間(予約開始日時 開始日時, 予約終了日時 終了日時) {
            _開始日時 = 開始日時;
            _終了日時 = 終了日時;

            if(_終了日時.時間が予約範囲外である())
            {
                throw new ArgumentException($"予約可能な時刻ではありません。");
            }
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

        //TODO: 日をまたいじゃダメにする。

        public bool 同じ日ですか(予約年月日 予約年月日)
        {
            return _開始日時.同じ日ですか(予約年月日)
                || _終了日時.同じ日ですか(予約年月日);
        }

        



        //todo: ビジネスルール：30日以内までしか予約できない

        // TODO:開始時刻とコマ数の組み合わせで、ちゃんと10:00-19:00の範囲で収まるかどうかを調べたい
        // TODO:開始時刻とコマ数の組み合わせで、終了時刻って実際何時なのか？
        // ↑これいつ必要？

    }
}
