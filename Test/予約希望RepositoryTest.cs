using System;
using Xunit;
using Reservation.Domain;
using Infrastructure;

namespace Test
{
    public class 予約希望RepositoryTest
    {
        [Fact]
        public void 予約希望をインスタンス化できること()
        {
            I予約希望Repository repository = new 予約希望Repository();

            Assert.NotNull(repository);
        }

        [Fact]
        public void 利用したい会議室が_先約がなければ_予約可能状態であることが分かる()
        {
            // ・予約可能かどうかが判定できる
            // 　・先約がなけれれば、予約可能ってわかる
            // 　・先約があるとkは、予約できないよ
            // 　・(他にも予約できない場合はあるかもしれないが、それはドメインエキスパートに聞こう！ 例えば、雨漏りがあって会議室が予約も使用もできないとか)

            I予約希望Repository repository = new 予約希望Repository();

            // TODO:trueを返すのはちょっと変
            Assert.Equal(repository.この会議室が予約可能かどうか教えて(null, null, null, null), true);
        }

        [Fact]
        public void 利用したい会議室が_先約があったら_予約不能状態であることが分かる()
        {
            I予約希望Repository repository = new 予約希望Repository();

            Assert.Equal(repository.この会議室が予約可能かどうか教えて(null, null, null, null), false); 
        }

        // 確認をする

        // TODO:Saveのテストも書く
    }
}
