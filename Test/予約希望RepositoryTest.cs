using System;
using Reservation.Domain;
using Reservation.Domain.Reservations;
using Reservation.Domain.Reservations.MeetingRooms;
using Reservation.Domain.Reservations.Period;
using Reservation.Infrastructure;
using Xunit;

namespace Test
{
    public class 予約希望RepositoryTest
    {
        [Fact]
        public void 予約希望をインスタンス化できること()
        {
            I予約希望Repository repository = new 予約希望Repository ();

            Assert.NotNull (repository);
        }

        // TODO: Saveメソッドが実装できたら、ここのテストをやります。
        // [Fact]
        // public void 利用したい会議室が_先約があったら_予約不能状態であることが分かる()
        // {
        //     I予約希望Repository repository = new 予約希望Repository();

        //     Assert.Equal(repository.この会議室が予約可能かどうか教えて(null, null, null, null), false); 
        // }

        // 確認をする

        // TODO:Saveのテストも書く
        [Fact]
        public void Aという会議室を予約して失敗する()
        {
            // このメソッドの中で
            I予約希望Repository repository = new 予約希望Repository ();

            var room = new MeetingRoom (MeetingRoomName.A);

            var ex = Assert.Throws<ArgumentException> (() =>
            {
                var range = new 予約期間(new 予約開始日時(new 予約年月日(2020, 2, 10), 予約開始_時._18, 予約_分._15),
                                        new 予約終了日時(new 予約年月日(2020, 2, 10), 予約終了_時._19, 予約_分._15)); // TODO： 予約終了時を作ったりするところからやる。コミットログ参照
                　
                var 予約希望 = new 予約希望(room, null, range, null);
                repository.Save (予約希望);
            });
        }

        [Fact]
        public void Aという会議室を予約する()
        {
            // このメソッドの中で
            I予約希望Repository repository = new 予約希望Repository ();

            var room = new MeetingRoom (MeetingRoomName.A);
            var range = new 予約期間(new 予約開始日時(new 予約年月日(2020, 2, 10), 予約開始_時._18, 予約_分._15),
                                    new 予約終了日時(new 予約年月日(2020, 2, 10), 予約終了_時._19, 予約_分._00));
            var 予約希望 = new 予約希望(room, null, range, null);
            repository.Save (予約希望);
        }

        // Aという会議室を予約するものは何やねん？？？
        // →　なにをアサーションすることは何だろう？

        // テストとアサーション

        // 確認すべきこと＝アサーション
        // アサーションのないテスト
        // テストケース

        // なんにも確認しないテスト。とは→　とにかくエラーが起きないこと。
        // なにも起きなかった。例外が起きなかったこと。
        // 

    }
}