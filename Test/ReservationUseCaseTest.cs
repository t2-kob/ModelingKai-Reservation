using System;
using Xunit;
using Reservation.Usecase;

using Reservation.Domain.Reservations;
using Reservation.Domain.Reservations.MeetingRooms;
using Reservation.Domain.Reservations.Period;
using Reservation.Infrastructure;
using Shouldly;


namespace Test
{
    public class ReservationUseCaseTest
    {
        [Fact]
        public void Aという会議室を予約する() {
            var useCase = new ReservationUseCase(new 予約希望Repository());

            var 予約できた = useCase.予約する(new MeetingRoom(MeetingRoomName.A),
                                              new ReserverId(),
                                              new 予約期間(new 予約年月日(2020, 3, 15), 予約開始_時._14, 予約開始_分._15, new コマ数(8)),
                                              new 想定使用人数());
            予約できた.ShouldBeTrue();
        }

        [Fact]
        public void Aという会議室を同じ条件で2回予約したら_2回目は予約失敗する()
        {
            var useCase = new ReservationUseCase(new 予約希望Repository());

            var 予約できた = useCase.予約する(new MeetingRoom(MeetingRoomName.A),
                                              new ReserverId(),
                                              new 予約期間(new 予約年月日(2020, 3, 15), 予約開始_時._14, 予約開始_分._15, new コマ数(8)),
                                              new 想定使用人数());
            予約できた.ShouldBeTrue();


            var _2回目も予約できた = useCase.予約する(new MeetingRoom(MeetingRoomName.A),
                                                      new ReserverId(),
                                                      new 予約期間(new 予約年月日(2020, 3, 15), 予約開始_時._14, 予約開始_分._15, new コマ数(8)),
                                                      new 想定使用人数());
            _2回目も予約できた.ShouldBeFalse();
        }

    }
}
