using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DevTrack.Foundation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace DevTrack.TrackerWorkerService
{
    public class Program
    {
        private static string _connectionString;
        private static string _migrationAssemblyName;
        private static IConfiguration _configuration;
        public static void Main(string[] args)
        {
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false)
                .AddEnvironmentVariables()
                .Build();

            _connectionString = _configuration.GetConnectionString("DefaultConnection");

            _migrationAssemblyName = typeof(Worker).Assembly.FullName;

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
                    var connectionStringName = "DefaultConnection";
                    var connectionString = _configuration.GetConnectionString(connectionStringName);
                    var migrationAssemblyName = typeof(Worker).Assembly.FullName;
                }).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex.Message, "Application startup is failed");
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
                    builder.RegisterModule(new FoundationModule(_connectionString, _migrationAssemblyName));
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                });
    }
}
