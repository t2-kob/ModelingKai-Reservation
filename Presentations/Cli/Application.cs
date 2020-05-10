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
        protected override void Main(string[] args)
        {
            // args => string[3] ===> B , "2020-05-10T12:00:00+09:00", "2020-05-10T13:00:00+09:00"
            var meetingRoom = new MeetingRoom((MeetingRoomName)Enum.Parse(typeof(MeetingRoomName), args[0]));
            var 予約開始DateTime = DateTime.Parse(args[1]);
            var 予約終了DateTime = DateTime.Parse(args[2]);


            予約開始日時 予約開始日時 = 予約時間Parser.予約開始日時をつくる(予約開始DateTime);
            予約終了日時 予約終了日時 = 予約時間Parser.予約終了日時をつくる(予約終了DateTime);

            var usecase = new ReservationUseCase(_repository);

            var 予約成功したか = usecase.予約する(new 予約希望(
                                                    meetingRoom,
                                                    new ReserverId(),
                                                    new 予約期間(予約開始日時, 予約終了日時),
                                                    new 想定使用人数())
                                                  );

            var test用の予約一覧ですよ = _repository.この日の予約一覧をください(new 予約年月日(2020, 5, 10));


            Debug.WriteLine($"予約成功したかどうか？ ==> {予約成功したか}");



            Debug.WriteLine("Hello World!");
        }

    }
}