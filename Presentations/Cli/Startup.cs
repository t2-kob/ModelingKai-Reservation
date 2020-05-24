using System.IO;
using Cli.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Reservation.Domain.Reservations;
using Reservation.Infrastructure;

namespace Cli
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
                    // ÉçÉOã@î\ÇÃDIê›íË
                    logging.AddConsole();
                    logging.AddDebug();
                })
                .ConfigureAppConfiguration(builder =>
                {
                    // ê›íËÉtÉ@ÉCÉãì«Ç›çûÇ›
                    builder.SetBasePath(Directory.GetCurrentDirectory());
                    builder.AddJsonFile("appsettings.json");
                    builder.AddJsonFile($"appsettings.{Env}.json");
                    builder.AddEnvironmentVariables();
                })
                .ConfigureServices((context, collection) =>
                {
                    // SampleSettingsÇÃDIê›íË
                    // collection.Configure<SampleSettings>(context.Configuration.GetSection(nameof(SampleSettings)));

                    // RepositoryÇÃDIê›íË
                    collection.AddSingleton<Ió\ñÒäÛñ]Repository, ó\ñÒäÛñ]Repository>();

                    // ControllerÇÃDIê›íË
                    collection.AddTransient<ó\ñÒController>();
                });
    }
}