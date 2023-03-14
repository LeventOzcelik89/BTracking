using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace BTracking.Web;

public class Program
{
    public async static Task<int> Main(string[] args)
    {

        Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Async(c => c.Console())
                .CreateLogger();

        try
        {
            Log.Information("Starting web host.");
            CreateHostBuilder(args).Build().Run();
            return 0;
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Host terminated unexpectedly!");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }

        //try
        //{
        //    Log.Information("Starting web host.");
        //    var builder = WebApplication.CreateBuilder(args);
        //    builder.Host.AddAppSettingsSecretsJson()
        //        .UseAutofac()
        //        .UseSerilog();
        //    await builder.AddApplicationAsync<BTrackingWebModule>();
        //    var app = builder.Build();
        //    await app.InitializeApplicationAsync();
        //    await app.RunAsync();
        //    return 0;
        //}
        //catch (Exception ex)
        //{
        //    Log.Fatal(ex, "Host terminated unexpectedly!");
        //    return 1;
        //}
        //finally
        //{
        //    Log.CloseAndFlush();
        //}
    }


    internal static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                 .ConfigureWebHostDefaults(webBuilder =>
                 {
                     webBuilder.UseStartup<Startup>();
                     if (!InsideIIS())
                     {
                         webBuilder.UseKestrel(options =>
                         {
                             options.Limits.MaxRequestBufferSize = long.MaxValue;
                             options.Limits.MaxRequestLineSize = int.MaxValue;
                             options.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(10);
                             options.Limits.MaxRequestBodySize = 209715200;
                         });
                     }
                 })
                .ConfigureAppConfiguration(build =>
                {
                    build.AddJsonFile("appsettings.secrets.json", optional: true);
                    build.AddJsonFile("appsettings.json", optional: true);
                    build.AddEnvironmentVariables();
                })
                .UseAutofac()
                .UseSerilog();

    public static bool InsideIIS() => Environment.GetEnvironmentVariable("APP_POOL_ID") is string;

}
