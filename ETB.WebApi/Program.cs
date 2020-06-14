using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using ETB.WebApi.DataAccess;
using Serilog;

namespace WebApi
{
    public class Program
    {
        //public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        //    .SetBasePath(Directory.GetCurrentDirectory())
        //    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        //    .AddEnvironmentVariables()
        //    .Build();

        public static void Main(string[] args)
        {
            //Log.Logger = new LoggerConfiguration()
            //    .ReadFrom.Configuration(Configuration.GetSection("Serilog"))
            //    .CreateLogger();

            try
            {
                var host = CreateWebHostBuilder(args).Build();
                //using (var scope = host.Services.CreateScope())
                //{
                //    var services = scope.ServiceProvider;
                //    try
                //    {
                //        var context = services.GetRequiredService<ETBContext>();
                //        DbInitializer.Initialize(context);
                //    }
                //    catch (Exception ex)
                //    {
                //        var logger = services.GetRequiredService<ILogger<Program>>();
                //        logger.LogError(ex, "An error occurred while seeding the database.");
                //    }
                //}
                host.Run();
                Log.Information("Started");
                //return;
            }
            catch (Exception)
            {
                //Log.Fatal(ex, "Host terminated unexpectedly");
                //Log.CloseAndFlush();
                //return;
            }
            finally
            {
                //Log.CloseAndFlush();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            //.UseKestrel()
            //.UseContentRoot(Directory.GetCurrentDirectory())
            //.ConfigureAppConfiguration((hostingContext, config) =>
            //{
            //    var env = hostingContext.HostingEnvironment;
            //    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            //          .AddJsonFile($"appsettings.{env.EnvironmentName}.json",
            //              optional: true, reloadOnChange: true);
            //    config.AddEnvironmentVariables();
            //})
            //.ConfigureLogging((hostingContext, logging) =>
            //{
            //    // Requires `using Microsoft.Extensions.Logging;`
            //    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
            //    logging.AddConsole();
            //    logging.AddDebug();
            //    logging.AddEventSourceLogger();
            //})
            .UseSerilog()
            .UseStartup<Startup>();
    }
}
