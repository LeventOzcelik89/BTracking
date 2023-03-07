using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace BTracking;

public class BTrackingWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<BTrackingWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
