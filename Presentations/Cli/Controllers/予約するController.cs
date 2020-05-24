using System;
using Microsoft.Extensions.Logging;
using Reservation.Domain.Reservations;
using Reservation.Domain.Reservations.MeetingRooms;
using Reservation.Domain.Reservations.Period;
using Reservation.Usecase;

namespace Cli.Controllers
{
    public class 予約するController : BaseController
    {
        private readonly I予約希望Repository _repository;

        public 予約するController(I予約希望Repository repository, ILogger<予約するController> logger) : base(logger)
        {
            _repository = repository;
        }

        /// <summary>
        /// メイン処理
        /// </summary>
        protected override void Main(string[] args)
        {
            // args => string[3] ===> B , "2020-05-10T12:00:00+09:00", "2020-05-10T13:00:00+09:00"

            予約希望 予約希望 = 予約希望つくる(args);
            var usecase = new ReservationUseCase(_repository);
            var 予約成功したか = usecase.予約する(予約希望);

            Logger.LogInformation($"予約成功したかどうか？ ==> {予約成功したか}");
        }

        private 予約希望 予約希望つくる(string[] args)
        {

            // TODO: パース(下準備) と、予約希望を作るところを分ける？
            // TODO: meetingRoom, 予約開始DateTime, 予約終了DateTime だけをパースとして分離する？
            // TODO: UIExceptionと、ドメインのExceptionとかを作る。 
            //           ==> (ここ→は改めて決定)層ごとに抽象例外クラスを作って、具体的な個々の例外はそのサブクラスにすると扱いやすいと思ってる。
            // TODO2: SQLite 入れるとか、永続化に関することも今後やりたい。

            var meetingRoom = new MeetingRoom((MeetingRoomName)Enum.Parse(typeof(MeetingRoomName), args[0])); //TODO: TryParse() にする？
            var 予約開始DateTime = DateTime.Parse(args[1]); // 同上
            var 予約終了DateTime = DateTime.Parse(args[2]);

            予約開始日時 予約開始日時 = 予約時間Parser.予約開始日時をつくる(予約開始DateTime);
            予約終了日時 予約終了日時 = 予約時間Parser.予約終了日時をつくる(予約終了DateTime);

            var 予約希望 = new 予約希望(meetingRoom,
                new ReserverId(),
                new 予約期間(予約開始日時, 予約終了日時),
                new 想定使用人数());

            return 予約希望;

        }
    }
}