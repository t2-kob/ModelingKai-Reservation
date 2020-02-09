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

        // こいつは,コマの数ではなくて、実は時間を返してあげる必要がある？

    }
}