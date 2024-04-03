using Serilog.Events;
using Serilog;
using Server.Library.Context;
namespace Server.Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Log.Logger = new LoggerConfiguration()
            //     .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            //     .MinimumLevel.Warning()
            //     .WriteTo.File("Logs/Services/Catalog/Catalog.Api.Log.txt", LogEventLevel.Warning,
            //     flushToDiskInterval: TimeSpan.FromSeconds(1), rollingInterval: RollingInterval.Day)
            //     .WriteTo.Console()
            //     .CreateLogger();


            try
            {
                Log.Warning("Starting  host");
                //CreateHostBuilder(args).Build().Run();

                var host = CreateHostBuilder(args).Build();
                SeedDatabase(host);
                host.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, $"Error details: {ex.Message}");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               //.UseSerilog()
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder.UseStartup<Startup>();

               })
               .UseDefaultServiceProvider(options => options.ValidateScopes = false);

        private static void SeedDatabase(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var moviesContext = services.GetRequiredService<ApplicationDbContext>();
                MovieSeeder.SeedAsync(moviesContext);
            }
        }
    }
}
