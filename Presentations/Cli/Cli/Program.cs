using Reservation.Infrastructure;
using Reservation.Usecase;
using System;
using System.Diagnostics;

namespace Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Infrastracture 層見えちゃってるけど、また考える。
            //       ==> DI する？ するとしたら何でやる？
            //              ==> ASP.Net 純正のDIのやつ、SimpleInjection、とかとか。
            //
            // TODO: ConsoleApp 系のフレームワーク使う？
            var usecase = new ReservationUseCase(new 予約希望Repository());

            Console.WriteLine("Hello World!");
            Debug.WriteLine("Hello World!");
        }
    }
}
