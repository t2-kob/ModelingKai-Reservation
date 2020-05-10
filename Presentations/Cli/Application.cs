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
            // TODO: args をパースするところからやる？

            // args => string[3] ===> B , "2020-05-10T12:00:00+09:00", "2020-05-10T13:00:00+09:00"

            var meetingRoom = new MeetingRoom((MeetingRoomName)Enum.Parse(typeof(MeetingRoomName), args[0]));
            var 予約開始DateTime = DateTime.Parse(args[1]);
            var 予約終了DateTime = DateTime.Parse(args[2]);

            var 予約開始年月日 = new 予約年月日(予約開始DateTime.Year, 予約開始DateTime.Month, 予約開始DateTime.Day);
            var 予約開始時 = (予約開始_時)Enum.Parse(typeof(予約開始_時), 予約開始DateTime.Hour.ToString());
            var 予約開始分 = (予約_分)Enum.Parse(typeof(予約_分), 予約開始DateTime.Minute.ToString());
            var 予約開始日時 = new 予約開始日時(予約開始年月日, 予約開始時, 予約開始分);


            var 予約終了年月日 = new 予約年月日(予約終了DateTime.Year, 予約終了DateTime.Month, 予約終了DateTime.Day);
            var 予約終了時 = (予約終了_時)Enum.Parse(typeof(予約終了_時), 予約終了DateTime.Hour.ToString());
            var 予約終了分 = (予約_分)Enum.Parse(typeof(予約_分), 予約終了DateTime.Minute.ToString());
            var 予約終了日時 = new 予約終了日時(予約終了年月日, 予約終了時, 予約終了分);


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