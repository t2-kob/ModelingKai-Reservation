using System;
using Cli.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = Startup.CreateHostBuilder().Build();

            var showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu(host);
            }
        }

        private static bool MainMenu(IHost host)
        {
            try
            {
                var now = DateTime.Now;

                Console.Clear();
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1) 予約する");
                Console.WriteLine("9) Exit");
                Console.Write("\r\nSelect an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        // ルーム選択
                        Console.WriteLine("\r\nChoose an room:");
                        Console.WriteLine("A) ルームA");
                        Console.WriteLine("B) ルームB");
                        Console.WriteLine("C) ルームC");
                        Console.Write("\r\nSelect a room: ");
                        var room = Console.ReadLine();

                        // 開始時間
                        Console.WriteLine($"\r\nStartDateTime? (Default: {now:d} 10:00:00): ");
                        var startDateTime = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(startDateTime))
                        {
                            startDateTime = new DateTime(now.Year, now.Month, now.Day, 10, 0, 0).ToString("G");
                            Console.WriteLine(startDateTime);
                        }

                        // 終了時間
                        Console.WriteLine($"\r\nEndDateTime? (Default: {now:d} 11:00:00): ");
                        var endDateTime = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(endDateTime))
                        {
                            endDateTime = new DateTime(now.Year, now.Month, now.Day, 11, 0, 0).ToString("G");
                            Console.WriteLine(endDateTime);
                        }

                        host.Services.GetRequiredService<予約Controller>().Run(new[] { room, startDateTime, endDateTime });
                        return true;
                    case "9":
                        return false;
                    default:
                        return true;
                }
            }
            finally
            {
                Console.WriteLine("\r\nPress any key...");
                Console.ReadLine();
            }
        }
    }
}