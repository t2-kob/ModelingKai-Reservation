using System;
using Reservation.Domain.Reservations;
using Reservation.Domain.Reservations.MeetingRooms;
using Reservation.Domain.Reservations.Period;
using Reservation.Infrastructure;
using Reservation.Usecase;
using Shouldly;
using Xunit;

namespace Test
{
    public class ReservationUseCaseTest
    {
        [Fact]
        public void Aという会議室を予約する()
        {
            var 予約希望 = new 予約希望(new MeetingRoom (MeetingRoomName.A),
                new ReserverId (),
                new 予約期間(new 予約開始日時(new 予約年月日(2020, 3, 15), 予約開始_時._14, 予約_分._15),
                            new 予約終了日時(new 予約年月日(2020, 3, 15), 予約終了_時._16, 予約_分._15)),
                new 想定使用人数());

            var useCase = new ReservationUseCase (new 予約希望Repository ());
            var 予約できた = useCase.予約する(予約希望);
            予約できた.ShouldBeTrue ();
        }

        [Fact]
        public void Aという会議室を_同じ条件で2回予約したら_2回目は予約失敗する()
        {
            var 予約希望 = new 予約希望(new MeetingRoom (MeetingRoomName.A),
                new ReserverId (),
                new 予約期間(new 予約開始日時(new 予約年月日(2020, 3, 15), 予約開始_時._14, 予約_分._15),
                            new 予約終了日時(new 予約年月日(2020, 3, 15), 予約終了_時._16, 予約_分._15)),
                new 想定使用人数());

            var useCase = new ReservationUseCase (new 予約希望Repository ());

            var 予約できた = useCase.予約する(予約希望);
            予約できた.ShouldBeTrue ();

            var _2回目の予約希望 = new 予約希望(new MeetingRoom (MeetingRoomName.A),
                new ReserverId (),
                new 予約期間(new 予約開始日時(new 予約年月日(2020, 3, 15), 予約開始_時._14, 予約_分._15),
                            new 予約終了日時(new 予約年月日(2020, 3, 15), 予約終了_時._16, 予約_分._15)),
                new 想定使用人数());

            var _2回目も予約できた = useCase.予約する(_2回目の予約希望);
            _2回目も予約できた.ShouldBeFalse ();
        }








        [Fact]
        public void Aという会議室を_終了を19時15分で予約したので_範囲外で失敗する()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var 予約希望 = new 予約希望(new MeetingRoom(MeetingRoomName.A),
                new ReserverId(),
                new 予約期間(new 予約開始日時(new 予約年月日(2020, 2, 10), 予約開始_時._18, 予約_分._15),
                             new 予約終了日時(new 予約年月日(2020, 2, 10), 予約終了_時._19, 予約_分._15)),
                new 想定使用人数());

                var useCase = new ReservationUseCase(new 予約希望Repository());

                var 予約できた = useCase.予約する(予約希望);
            });

            // Exceptionが出て OK.
        }

        [Fact]
        public void Aという会議室を_終了を19時00分で予約できること()
        {

            var 予約希望 = new 予約希望(new MeetingRoom(MeetingRoomName.A),
                                        new ReserverId(),
                                        new 予約期間(new 予約開始日時(new 予約年月日(2020, 2, 10), 予約開始_時._18, 予約_分._15),
                                                     new 予約終了日時(new 予約年月日(2020, 2, 10), 予約終了_時._19, 予約_分._00)),
                                        new 想定使用人数());

            var useCase = new ReservationUseCase(new 予約希望Repository());

            var 予約できた = useCase.予約する(予約希望);
            予約できた.ShouldBeTrue();
        }


        [Fact]
        public void Aという会議室を_終了を10時00分で予約したので_範囲外で失敗する()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var 予約希望 = new 予約希望(new MeetingRoom(MeetingRoomName.A),
                new ReserverId(),
                new 予約期間(new 予約開始日時(new 予約年月日(2020, 2, 10), 予約開始_時._10, 予約_分._00),
                             new 予約終了日時(new 予約年月日(2020, 2, 10), 予約終了_時._10, 予約_分._00)),
                new 想定使用人数());

                var useCase = new ReservationUseCase(new 予約希望Repository());

                var 予約できた = useCase.予約する(予約希望);
            });

            // Exceptionが出て OK.
        }


        [Fact]
        public void Aという会議室を_終了を10時15分で予約できること()
        {

            var 予約希望 = new 予約希望(new MeetingRoom(MeetingRoomName.A),
                                        new ReserverId(),
                                        new 予約期間(new 予約開始日時(new 予約年月日(2020, 2, 10), 予約開始_時._10, 予約_分._00),
                                                     new 予約終了日時(new 予約年月日(2020, 2, 10), 予約終了_時._10, 予約_分._15)),
                                        new 想定使用人数());

            var useCase = new ReservationUseCase(new 予約希望Repository());

            var 予約できた = useCase.予約する(予約希望);
            予約できた.ShouldBeTrue();
        }

    }
}