using System;
using System.Diagnostics;
using Cli.Applications;
using Reservation.Domain.Reservations;
using Reservation.Domain.Reservations.MeetingRooms;
using Reservation.Domain.Reservations.Period;
using Reservation.Usecase;

namespace Cli
{
    public class Application : BaseApplication
    {
        private readonly I予約希望Repository _repository;

        public Application(I予約希望Repository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// メイン処理
        /// </summary>
        protected override void Main()
        {
            var usecase = new ReservationUseCase(_repository);

            var 予約成功したか = usecase.予約する(new 予約希望(
                                                    new MeetingRoom(MeetingRoomName.B),
                                                    new ReserverId(), 
                                                    new 予約期間(new 予約開始日時(new 予約年月日(2020, 5, 10), 予約開始_時._10, 予約_分._00),
                                                                 new 予約終了日時(new 予約年月日(2020, 5, 10), 予約終了_時._17, 予約_分._30)),
                                                    new 想定使用人数())
                                                  );

            var test用の予約一覧ですよ = _repository.この日の予約一覧をください(new 予約年月日(2020, 5, 10));


            Debug.WriteLine($"予約成功したかどうか？ ==> {予約成功したか}");
            


            Debug.WriteLine("Hello World!");
        }
    }
}