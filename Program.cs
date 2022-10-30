using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using SimpleStoreWeb.Data;
using SimpleStoreWeb.Extensions;

namespace SimpleShop
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.MigratePending<SimpleStoreDbContext>();
            // NoSeed checks only if some roles are created.
            // Аfter this check blindly assumes that the operation was successful.
            // For future development it is good to move into SimpleStoreDbContext.
            if (host.NoSeed())
            {
                host.AddPredefinedRoles().Wait();
                host.AddPredefinedUsers().Wait();
                host.AddPredefinedCategoies().Wait();
                host.AddProducts().Wait();
            }

            host.Run();
        }
        
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(SetupConfiguration)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void SetupConfiguration(HostBuilderContext ctx, IConfigurationBuilder builder)
        {
            builder.AddJsonFile(
                "appsettings.json",
                optional: true,
                reloadOnChange: true);
        }
    }
}
