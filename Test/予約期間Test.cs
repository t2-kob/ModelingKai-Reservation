using System;
using Xunit;
using Reservation.Domain;
using Infrastructure;

namespace Test
{

    public class 予約期間Test
    {
        private static readonly 予約期間 _target = new 予約期間(new 予約年月日(2020, 2, 23), 予約開始_時._14, 予約開始_分._00, new コマ数(8));

        public class NGの場合
        {


            [Fact]
            public void 後ろが被るのでNG()
            {
                var me = new 予約期間(new 予約年月日(2020, 2, 23), 予約開始_時._13, 予約開始_分._00, new コマ数(8));
                var result = me.時間かぶってますか(_target);
                Assert.True(result);
            }

            [Fact]
            public void 前が被るのでNG()
            {
                Assert.True(false); // TODO: 以下全部の Assert.True(false); なんとかしよう
            }

            [Fact]
            public void 包含されるのでNG()
            {
                Assert.True(false);
            }

            [Fact]
            public void 包含するのでNG()
            {
                Assert.True(false);
            }

            [Fact]
            public void 開始時刻が被るのでNG()
            {
                Assert.True(false);
            }

            [Fact]
            public void 終了時刻が被るのでNG()
            {
                Assert.True(false);
            }

            [Fact]
            public void 開始時刻と終了時刻が両方被るのでNG()
            {
                Assert.True(false);
            }



        }

        public class 手前側のOK
        {
            [Fact]
            public void 終了時刻が_対象の開始時刻より前だからOK()
            {
                var me = new 予約期間(new 予約年月日(2020, 2, 23), 予約開始_時._10, 予約開始_分._00, new コマ数(8));
                var result = me.時間かぶってますか(_target);
                Assert.False(result);

            }
            [Fact]
            public void 終了時刻と_対象の開始時刻が同じだけどOK()
            {
                Assert.True(false);
            }

        }
        public class 後ろ側のOK
        {

            [Fact]
            public void 開始時刻が_対象の終了時刻より後だからOK()
            {
                Assert.True(false);
            }
            [Fact]
            public void 開始時刻と_対象の終了時刻が同じだけどOK()
            {
                Assert.True(false);
            }
        }
    }
}
