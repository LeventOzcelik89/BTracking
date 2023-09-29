using BTracking.FNC.FinanceDailyData;
using BTracking.UT.Cities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BTracking.Browser
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.


            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = CreateHostBuilder().Build();

            host.RunAsync().ConfigureAwait(true);
            var cc = host.Services.GetService<ICityRepository>();
            var mk = host.Services.GetService<IFinanceDailyDataRepository>();

            ApplicationConfiguration.Initialize();
            //  Application.Run(new Form1());
            Application.Run(host.Services.GetRequiredService<DailyData>());
        }

        private static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    services.AddHostedService<TimedHostedService>();
                    services.AddTransient<DailyData>();
                });
        }

    }
}