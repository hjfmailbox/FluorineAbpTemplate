using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace FluorineAbpProjectName;

public class Program
{
    public async static Task<int> Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
#if DEBUG
            .MinimumLevel.Debug()
#else
            .MinimumLevel.Information()
#endif
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .WriteTo.Logger(x => x.Filter.ByIncludingOnly(y => y.Level == LogEventLevel.Verbose)
            .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Logs/{DateTime.Now:yyyy-MM}/Verbose-.log"), rollingInterval: RollingInterval.Day))
            .WriteTo.Logger(x => x.Filter.ByIncludingOnly(y => y.Level == LogEventLevel.Debug)
            .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Logs/{DateTime.Now:yyyy-MM}/Debug-.log"), rollingInterval: RollingInterval.Day))
            .WriteTo.Logger(x => x.Filter.ByIncludingOnly(y => y.Level == LogEventLevel.Information)
            .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Logs/{DateTime.Now:yyyy-MM}/Information-.log"), rollingInterval: RollingInterval.Day))
            .WriteTo.Logger(x => x.Filter.ByIncludingOnly(y => y.Level == LogEventLevel.Warning)
            .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Logs/{DateTime.Now:yyyy-MM}/Warning-.log"), rollingInterval: RollingInterval.Day))
            .WriteTo.Logger(x => x.Filter.ByIncludingOnly(y => y.Level == LogEventLevel.Error)
            .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Logs/{DateTime.Now:yyyy-MM}/Error-.log"), rollingInterval: RollingInterval.Day))
            .WriteTo.Logger(x => x.Filter.ByIncludingOnly(y => y.Level == LogEventLevel.Fatal)
            .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Logs/{DateTime.Now:yyyy-MM}/Fatal-.log"), rollingInterval: RollingInterval.Day))
            .WriteTo.Async(c => c.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Logs/{DateTime.Now:yyyy-MM}/All-.log"), rollingInterval: RollingInterval.Day))
            .WriteTo.Async(c => c.Console())
            .CreateLogger();

        try
        {
            Log.Information("Starting FluorineAbpProjectName.HttpApi.Host.");
            var builder = WebApplication.CreateBuilder(args);
            builder.Host.AddAppSettingsSecretsJson()
                .UseAutofac()
                .UseSerilog();
            await builder.AddApplicationAsync<FluorineAbpProjectNameHttpApiHostModule>();
            var app = builder.Build();
            await app.InitializeApplicationAsync();
            await app.RunAsync();
            return 0;
        }
        catch (Exception ex)
        {
            // Ignore StopTheHostException when execute Add-Migration
            string type = ex.GetType().Name;
            if (type.Equals("StopTheHostException", StringComparison.Ordinal))
            {
                throw;
            }
            Log.Fatal(ex, "Host terminated unexpectedly!");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
