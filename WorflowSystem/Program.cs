using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Worflow.Seeding;

namespace WorflowSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DataBaseGenerator.Seed();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
