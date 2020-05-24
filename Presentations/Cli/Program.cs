using Cli.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace Cli
{
    class Program
    {
        private static void Main(string[] args)
        {
            var host = Startup.CreateHostBuilder().Build();

            var application = host.Services.GetRequiredService<IController>();

            application.Run(args);
        }
    }
}