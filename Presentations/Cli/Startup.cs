using System.IO;
using Cui.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Reservation.Domain.Reservations;
using Reservation.Infrastructure;

namespace Cui
{
    internal static class Startup
    {
        private static string Env =>
#if DEBUG
            "Development";
#else
            "Production";
#endif

        public static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureLogging(logging =>
                {
                    // ログ機能のDI設定
                    logging.AddConsole();
                    logging.AddDebug();
                })
                .ConfigureAppConfiguration(builder =>
                {
                    // 設定ファイル読み込み
                    builder.SetBasePath(Directory.GetCurrentDirectory());
                    builder.AddJsonFile("appsettings.json");
                    builder.AddJsonFile($"appsettings.{Env}.json");
                    builder.AddEnvironmentVariables();
                })
                .ConfigureServices((context, collection) =>
                {
                    // SampleSettingsのDI設定
                    // collection.Configure<SampleSettings>(context.Configuration.GetSection(nameof(SampleSettings)));

                    // RepositoryのDI設定
                    collection.AddSingleton<I予約希望Repository, 予約希望Repository>();

                    // ControllerのDI設定
                    collection.AddTransient<予約Controller>();
                    collection.AddTransient<予約一覧Controller>();
                });
    }
}