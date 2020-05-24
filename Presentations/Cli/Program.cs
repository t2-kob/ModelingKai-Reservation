using Cli.Applications;
using Microsoft.Extensions.DependencyInjection;

namespace Cli
{
    class Program
    {
        private static void Main(string[] args)
        {
            var host = Startup.CreateHostBuilder().Build();

            var application = host.Services.GetRequiredService<IApplication>();

            application.Run(args);
        }
    }
}