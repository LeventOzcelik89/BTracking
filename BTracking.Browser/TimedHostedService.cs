using HiveMQtt.Client.Events;
using Microsoft.Extensions.Hosting;

namespace BTracking.Browser
{
    public class TimedHostedService : BackgroundService
    {
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var conres = await Publisher.GetClient().ConnectAsync().ConfigureAwait(false);
            Publisher.GetClient().OnMessageReceived += MessageReceived;
            Publisher.GetClient().SubscribeAsync("btracking/finance/runmonthly").ConfigureAwait(false);
        }

        private async void MessageReceived(object? sender, OnMessageReceivedEventArgs e)
        {
            Form1.form1.NavigateMonthly("https://tr.investing.com/equities/trending-stocks");
            //  new BrowserBase().GetMonthly();
        }

    }
}
