using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace TourOfHeroes.Web
{
    /// <summary>
    /// Main program.
    /// </summary>
    /// <remarks>
    /// https://docs.microsoft.com/en-us/aspnet/core/razor-pages/ui-class?view=aspnetcore-3.0&tabs=netcore-cli#consume-content-from-a-referenced-rcl
    /// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/environments?view=aspnetcore-3.0
    /// </remarks>
    public static class Program
    {
        /// <summary>
        /// Main entry point for the application.
        /// </summary>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <inheritdoc/>        
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // Static web assets are enabled by default in the Development environment.
                    // UseStaticWebAssets will support assets in other environments.
                    webBuilder.UseStaticWebAssets();
                    webBuilder.UseStartup<Startup>();
                });
    }
}
