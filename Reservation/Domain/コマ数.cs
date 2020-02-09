using System;

namespace Reservation.Domain {
    public class コマ数 {
        // コマ数の制約ってなに？

        // 生成条件としては、
        // 0コマは取れない
        // マイナスは取れない

        private readonly int Value;

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