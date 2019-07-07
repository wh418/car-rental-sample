using System.Threading.Tasks;
using CarRental.Core.Config;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace CarRental.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            await host.Services.SetupCore();

            await host.RunAsync();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
