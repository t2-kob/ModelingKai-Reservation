using System;

namespace Reservation.Domain {
    public class コマ数 {
        // コマ数の制約ってなに？

        // 生成条件としては、
        // 0コマは取れない
        // マイナスは取れない

        private readonly int Value;
        private const int コマあたりの分数 = 15;

        public コマ数(int value)
        {
            if (value <= 0)
                throw new ArgumentException(nameof(value));

            this.Value = value;
        }

        public bool に引数が収まっているか教えて(コマ数 対象)
        {
            return this.Value >= 対象.Value;
        }
        // こいつは,コマの数ではなくて、実は時間を返してあげる必要がある？

        public static コマ数 ある期間のコマ数を教えて(int 開始_時, int 開始_分, int 終了_時, int 終了_分)
        {
            // TODO:日付と秒は適当
            // 日付は関係ない！
            DateTime time = new DateTime(1900, 1, 1, 開始_時, 開始_分, 0);
            DateTime endTime = new DateTime(1900, 1, 1, 終了_時, 終了_分, 0);

            int miniute = (int)(endTime - time).TotalMinutes;
            
            return new コマ数(miniute / コマあたりの分数);
        }

        public static bool operator <(コマ数 c1, コマ数 c2)
        {
            return c1.Value < c2.Value;
        }
        public static bool operator >(コマ数 c1, コマ数 c2)
        {
            return c1.Value > c2.Value;
        }

        public static bool operator <=(コマ数 c1, コマ数 c2)
        {
            return c1.Value <= c2.Value;
        }

        public static bool operator >=(コマ数 c1, コマ数 c2)
        {
            return c1.Value >= c2.Value;
        }

    }
}