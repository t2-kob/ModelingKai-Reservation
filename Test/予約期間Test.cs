using System;
using Xunit;
using Reservation.Domain;
using Infrastructure;

namespace Test
{
    public class 予約期間Test
    {
        /// <summary>
        /// 14:00~16:00
        /// </summary>
        private static readonly 予約期間 _target = new 予約期間(new 予約年月日(2020, 2, 23), 予約開始_時._14, 予約開始_分._00, new コマ数(8));

        public class 期間が被っている場合 
        {
            /// <summary>
            /// 対象 14:00~16:00   |====|
            /// 自分 13:00~15:00 |====|
            /// </summary>
            [Fact]
            public void 後ろが被る()
            {
                var me = new 予約期間(new 予約年月日(2020, 2, 23), 予約開始_時._13, 予約開始_分._00, new コマ数(8));
                var 被っている = me.時間かぶってますか(_target);
                Assert.True(被っている);
            }

            /// <summary>
            /// 対象 14:00~16:00   |====|
            /// 自分 15:00~17:00      |====|
            /// </summary>
            [Fact]
            public void 前が被る()
            {
                var me = new 予約期間(new 予約年月日(2020, 2, 23), 予約開始_時._15, 予約開始_分._00, new コマ数(8));
                var 被っている = me.時間かぶってますか(_target);
                Assert.True(被っている);
            }

            /// <summary>
            /// 対象 14:00~16:00   |====|
            /// 自分 14:30~15:30    |==|
            /// </summary>
            [Fact]
            public void 包含される()
            {
                var me = new 予約期間(new 予約年月日(2020, 2, 23), 予約開始_時._14, 予約開始_分._30, new コマ数(4));
                var 被っている = me.時間かぶってますか(_target);
                Assert.True(被っている);
            }

            /// <summary>
            /// 対象 14:00~16:00   |====|
            /// 自分 13:30~16:30 |========|
            /// </summary>
            [Fact]
            public void 包含する()
            {
                var me = new 予約期間(new 予約年月日(2020, 2, 23), 予約開始_時._13, 予約開始_分._30, new コマ数(12));
                var 被っている = me.時間かぶってますか(_target);
                Assert.True(被っている);
            }

            /// <summary>
            /// 境界値テスト
            /// 対象 14:00~16:00   |====|
            /// 自分 14:00~15:00   |==|
            /// </summary>
            [Fact]
            public void 開始時刻が被る()
            {
                var me = new 予約期間(new 予約年月日(2020, 2, 23), 予約開始_時._14, 予約開始_分._00, new コマ数(4));
                var 被っている = me.時間かぶってますか(_target);
                Assert.True(被っている);
            }

            /// <summary>
            /// 境界値テスト
            /// 対象 14:00~16:00   |====|
            /// 自分 15:00~16:00     |==|
            /// </summary>
            [Fact]
            public void 終了時刻が被る()
            {
                var me = new 予約期間(new 予約年月日(2020, 2, 23), 予約開始_時._15, 予約開始_分._00, new コマ数(4));
                var 被っている = me.時間かぶってますか(_target);
                Assert.True(被っている);
            }

            /// <summary>
            /// 境界値テスト
            /// 対象 14:00~16:00   |====|
            /// 自分 14:00~16:00   |====|
            /// </summary>
            [Fact]
            public void 開始時刻と終了時刻が両方被る()
            {
                var me = new 予約期間(new 予約年月日(2020, 2, 23), 予約開始_時._14, 予約開始_分._00, new コマ数(8));
                var 被っている = me.時間かぶってますか(_target);
                Assert.True(被っている);
            }
        }

        public class 手前側で被ってない場合
        {
            /// <summary>
            /// 対象 14:00~16:00    |====|
            /// 自分 13:00~13:30 |=|
            /// </summary>
            [Fact]
            public void 終了時刻が_対象の開始時刻より前()
            {
                var me = new 予約期間(new 予約年月日(2020, 2, 23), 予約開始_時._13, 予約開始_分._30, new コマ数(2));
                var 被っている = me.時間かぶってますか(_target);
                Assert.False(被っている);
            }

            /// <summary>
            /// 境界値テスト
            /// 対象 14:00~16:00    |====|
            /// 自分 13:00~14:00 |==|
            /// </summary>
            [Fact]
            public void 終了時刻と_対象の開始時刻が同じ()
            {
                var me = new 予約期間(new 予約年月日(2020, 2, 23), 予約開始_時._13, 予約開始_分._00, new コマ数(4));
                var 被っている = me.時間かぶってますか(_target);
                Assert.False(被っている);
            }

        }
        public class 後ろ側で被っていない場合
        {
            /// <summary>
            /// 対象 14:00~16:00    |====|
            /// 自分 16:30~17:00          |=|
            /// </summary>
            [Fact]
            public void 開始時刻が_対象の終了時刻より後()
            {
                var me = new 予約期間(new 予約年月日(2020, 2, 23), 予約開始_時._16, 予約開始_分._30, new コマ数(2));
                var 被っている = me.時間かぶってますか(_target);
                Assert.False(被っている);
            }

            /// <summary>
            /// 境界値テスト
            /// 対象 14:00~16:00    |====|
            /// 自分 16:00~17:00         |==|
            /// </summary>
            [Fact]
            public void 開始時刻と_対象の終了時刻が同じ()
            {
                var me = new 予約期間(new 予約年月日(2020, 2, 23), 予約開始_時._16, 予約開始_分._00, new コマ数(4));
                var 被っている = me.時間かぶってますか(_target);
                Assert.False(被っている);
            }
        }
    }
}
