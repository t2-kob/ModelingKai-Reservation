using System;
using System.Diagnostics;
using Cli.Applications;
using Reservation.Domain.Reservations;
using Reservation.Usecase;

namespace Cli
{
    public class Application : IApplication
    {
        private readonly I予約希望Repository _repository;

        public Application(I予約希望Repository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// メイン処理
        /// </summary>
        public void Run()
        {
            var usecase = new ReservationUseCase(_repository);

            Console.WriteLine("Hello World!");
            Debug.WriteLine("Hello World!");
        }
    }
}