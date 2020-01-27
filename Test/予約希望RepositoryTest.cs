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

        // メソッド名にtrueとかが入っているのが変
        [Fact]
        public void 空きが確認できたらtrueを返す()
        {
            I予約希望Repository repository = new 予約希望Repository();
            // TODO:仮実装

            bool result = repository.空きを確認する(null, null, null, null);

            Assert.True(result);
        }

        [Fact]
        public void 使いたい部屋が空いていた場合のテスト()
        {
            I予約希望Repository repository = new 予約希望Repository();

            // TODO:trueを返すのはちょっと変
            Assert.Equal(repository.空きを確認する(null, null, null, null), true);
        }

        [Fact]
        public void 使いたい部屋が空いてなかった場合のテスト()
        {
            I予約希望Repository repository = new 予約希望Repository();

            Assert.Equal(repository.空きを確認する(null, null, null, null), false); 
        }

        // 確認をする

        // TODO:Saveのテストも書く
    }
}
