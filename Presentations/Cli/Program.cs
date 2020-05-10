using Microsoft.Extensions.DependencyInjection;
using Cli.Applications;
using Reservation.Domain.Reservations;
using Reservation.Infrastructure;

namespace Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            InitializeApplication().Run(args);
        }

        private static IApplication InitializeApplication()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            return serviceCollection.BuildServiceProvider()
                .GetService<IApplication>();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            // RepositoryのDI設定
            services.AddTransient<I予約希望Repository, 予約希望Repository>();

            // ApplicationのDI設定
            services.AddTransient<IApplication, Application>();
        }
    }
}
