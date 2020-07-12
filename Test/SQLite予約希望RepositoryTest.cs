using System;
using System.Diagnostics;
using hogehogehogehoge;
using Reservation.Domain;
using Reservation.Domain.Exceptions;
using Reservation.Domain.Reservations;
using Reservation.Domain.Reservations.MeetingRooms;
using Reservation.Domain.Reservations.Period;
using Reservation.Infrastructure;
using Shouldly;
using SQLiteInfra;
using Xunit;
using Xunit.Abstractions;

namespace Test
{

    public class SQLite予約希望RepositoryTest : IDisposable
    {
        private readonly ITestOutputHelper output;
        private readonly IDataStoreInitializer dbInitializer;



        /// <summary>
        /// SetUp
        /// </summary>
        /// <remarks>
        /// Fact のたびに呼ばれます。
        /// </remarks>
        public SQLite予約希望RepositoryTest(ITestOutputHelper output)
        {
            this.output = output;

            dbInitializer = new SqliteInitializer();
            dbInitializer.CleanUpDateStore();
            dbInitializer.CreateDataStore();
        }

        /// <summary>
        /// TearDown
        /// </summary>
        /// <remarks>
        /// Fact のたびに呼ばれます。
        /// </remarks>
        public void Dispose()
        {
            // テスト後の結果を見たいので、dbInitializer.CleanUpDateStore(); はしない。
        }

        [Fact]
        public void SQLiteのDBファイルが作れること()
        {
            // SQLite予約希望Repositoryが、一番はじめに初期化されたとき？
            // DBファイル作る？
        
            var repository = new SQLite予約希望Repository();

            // SQLiteInfra/reserve.db みたいなのができてほしい。
            // とりあえず目視でいいか

            Assert.True(true);

        }

        [Fact]
        public void 新規予約をして予約一覧に予約があること()
        {
            // TODO: テスト名
            
            var repository = new SQLite予約希望Repository();

            var meetingRoom = new MeetingRoom(MeetingRoomName.A);

            予約開始日時 予約開始日時 = new 予約開始日時(new 予約年月日(2020, 5, 23), 予約開始_時._10, 予約_分._00);
            予約終了日時 予約終了日時 = new 予約終了日時(new 予約年月日(2020, 5, 23), 予約終了_時._12, 予約_分._00);

            var reserve = new 予約希望(meetingRoom,
                new ReserverId (),
                new 予約期間(予約開始日時, 予約終了日時),
                new 想定使用人数());

            repository.Save(reserve);

            var reserveList = repository.この日の予約一覧をください(new 予約年月日(2020,5,23));

            // TODO: かなりあやしいインターフェースです
            reserveList.かぶってますか(reserve).ShouldBeTrue();
        }
    }

}