using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DevTrack.Foundation;
using DevTrack.Foundation.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace DevTrack.TrackerWorkerService
{
    public class Program
    {
        private static IConfiguration _configuration;
        private static string _connectionString;
        private static string _migrationAssemblyName;

        public static void Main(string[] args)
        {
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false)
                .AddEnvironmentVariables()
                .Build();

            _connectionString = _configuration.GetConnectionString("SqliteConnection");
            _migrationAssemblyName = typeof(Worker).Assembly.GetName().Name;

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .ReadFrom.Configuration(_configuration)
                .CreateLogger();
            try
            {
                Log.Information("Application starting up...");
                CreateHostBuilder(args).ConfigureServices((hostContext, services) =>
                {
                    var connectionStringName = "SqliteConnection";
                    var connectionString = _configuration.GetConnectionString(connectionStringName);
                    var migrationAssemblyName = typeof(Worker).Assembly.GetName().Name;
                }).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .UseSerilog()
                .ConfigureContainer<ContainerBuilder>(builder => {
                    builder.RegisterModule(new WorkerModule());
                    builder.RegisterModule(new FoundationModule(_connectionString,_migrationAssemblyName));
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    services.AddDbContext<DevTrackContext>();
                });
    }
}
