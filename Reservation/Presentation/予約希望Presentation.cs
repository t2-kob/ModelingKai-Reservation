using Reservation.Usecase;
using System;
using System.Collections.Generic;
using System.Text;
using Reservation.Domain.Reservations.MeetingRooms;
using Reservation.Domain.Reservations;
using Reservation.Domain.Reservations.Period;

namespace Reservation.Presentation
{
    public class 予約希望Presentation
    {

        public void 予約1() {
            new ReservationUseCase().予約する(new MeetingRoom(roomName), 
                                              new ReserverId(reserverId),
                                              new 予約期間(new 予約年月日(start.Year, start.Month, .... ), ...)
                                              new 想定使用人数());
        }
        public void 予約2()
        {
            var 希望 = new 予約希望(new MeetingRoom(roomName),
                                    new ReserverId(reserverId),
                                    new 予約期間(new 予約年月日(start.Year, start.Month, ....), ...)
                                    new 想定使用人数());

            new ReservationUseCase().予約する(希望);
        }
        public void 予約3()
        {
            new ReservationUseCase().予約する(roomName, reserverId, DateTime start, DateTime end, ...);
        }

        public void 予約4()
        {
            予約希望 希望 = new 予約希望つくるUseCase(roomName, reserverId, DateTime start, DateTime end, ...);
            new ReservationUseCase().予約する(希望);
        }

    }
}
