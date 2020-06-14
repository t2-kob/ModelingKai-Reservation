using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Cli.Applications;
// using Cli.Configs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Reservation.Domain.Reservations;
using Reservation.Infrastructure;

namespace Cli
{
    class Program
    {
        private static string Env =>
#if DEBUG
            "Development";
#else
            "Production";
#endif

        static void Main(string[] args)
        {
            var host = CreateHostBuilder().Build();

            var application = host.Services.GetRequiredService<IApplication>();

            application.Run(args);
        }

        private static IHostBuilder CreateHostBuilder() =>
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
                    collection.AddTransient<I予約希望Repository, 予約希望Repository>();

                    // ApplicationのDI設定
                    collection.AddTransient<IApplication, Application>();
                });
    }
}
