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

        public class NGの場合
        {
            /// <summary>
            /// 対象 14:00~16:00   |====|
            /// 自分 13:00~15:00 |====|
            /// </summary>
            [Fact]
            public void 後ろが被るのでNG()
            {
                var me = new 予約期間(new 予約年月日(2020, 2, 23), 予約開始_時._13, 予約開始_分._00, new コマ数(8));
                var result = me.時間かぶってますか(_target);
                Assert.True(result);
            }

            /// <summary>
            /// 対象 14:00~16:00   |====|
            /// 自分 15:00~17:00      |====|
            /// </summary>
            [Fact]
            public void 前が被るのでNG()
            {
                var me = new 予約期間(new 予約年月日(2020, 2, 23), 予約開始_時._15, 予約開始_分._00, new コマ数(8));
                var result = me.時間かぶってますか(_target);
                Assert.True(result);
            }

            /// <summary>
            /// 対象 14:00~16:00   |====|
            /// 自分 14:30~15:30    |==|
            /// </summary>
            [Fact]
            public void 包含されるのでNG()
            {
                var me = new 予約期間(new 予約年月日(2020, 2, 23), 予約開始_時._14, 予約開始_分._30, new コマ数(4));
                var result = me.時間かぶってますか(_target);
                Assert.True(result);
            }

            /// <summary>
            /// 対象 14:00~16:00   |====|
            /// 自分 13:30~16:30 |========|
            /// </summary>
            [Fact]
            public void 包含するのでNG()
            {
                var me = new 予約期間(new 予約年月日(2020, 2, 23), 予約開始_時._13, 予約開始_分._30, new コマ数(12));
                var result = me.時間かぶってますか(_target);
                Assert.True(result);
            }

            /// <summary>
            /// 境界値テスト
            /// 対象 14:00~16:00   |====|
            /// 自分 14:00~15:00   |==|
            /// </summary>
            [Fact]
            public void 開始時刻が被るのでNG()
            {
                var me = new 予約期間(new 予約年月日(2020, 2, 23), 予約開始_時._14, 予約開始_分._00, new コマ数(4));
                var result = me.時間かぶってますか(_target);
                Assert.True(result);
            }

            /// <summary>
            /// 境界値テスト
            /// 対象 14:00~16:00   |====|
            /// 自分 15:00~16:00     |==|
            /// </summary>
            [Fact]
            public void 終了時刻が被るのでNG()
            {
                var me = new 予約期間(new 予約年月日(2020, 2, 23), 予約開始_時._15, 予約開始_分._00, new コマ数(4));
                var result = me.時間かぶってますか(_target);
                Assert.True(result);
            }

            /// <summary>
            /// 境界値テスト
            /// 対象 14:00~16:00   |====|
            /// 自分 14:00~16:00   |====|
            /// </summary>
            [Fact]
            public void 開始時刻と終了時刻が両方被るのでNG()
            {
                var me = new 予約期間(new 予約年月日(2020, 2, 23), 予約開始_時._14, 予約開始_分._00, new コマ数(8));
                var result = me.時間かぶってますか(_target);
                Assert.True(result);
            }
        }

        public class 手前側のOK
        {
            /// <summary>
            /// 対象 14:00~16:00    |====|
            /// 自分 13:00~13:30 |=|
            /// </summary>
            [Fact]
            public void 終了時刻が_対象の開始時刻より前だからOK()
            {
                var me = new 予約期間(new 予約年月日(2020, 2, 23), 予約開始_時._13, 予約開始_分._30, new コマ数(2));
                var result = me.時間かぶってますか(_target);
                Assert.False(result);
            }

            /// <summary>
            /// 境界値テスト
            /// 対象 14:00~16:00    |====|
            /// 自分 13:00~14:00 |==|
            /// </summary>
            [Fact]
            public void 終了時刻と_対象の開始時刻が同じだけどOK()
            {
                var me = new 予約期間(new 予約年月日(2020, 2, 23), 予約開始_時._13, 予約開始_分._00, new コマ数(4));
                var result = me.時間かぶってますか(_target);
                Assert.False(result);
            }

        }
        public class 後ろ側のOK
        {
            /// <summary>
            /// 対象 14:00~16:00    |====|
            /// 自分 16:30~17:00          |=|
            /// </summary>
            [Fact]
            public void 開始時刻が_対象の終了時刻より後だからOK()
            {
                var me = new 予約期間(new 予約年月日(2020, 2, 23), 予約開始_時._16, 予約開始_分._30, new コマ数(2));
                var result = me.時間かぶってますか(_target);
                Assert.False(result);
            }

            /// <summary>
            /// 境界値テスト
            /// 対象 14:00~16:00    |====|
            /// 自分 16:00~17:00         |==|
            /// </summary>
            [Fact]
            public void 開始時刻と_対象の終了時刻が同じだけどOK()
            {
                var me = new 予約期間(new 予約年月日(2020, 2, 23), 予約開始_時._16, 予約開始_分._00, new コマ数(4));
                var result = me.時間かぶってますか(_target);
                Assert.False(result);
            }
        }
    }
}
