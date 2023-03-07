using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BTracking.Data;
using Volo.Abp.DependencyInjection;

namespace BTracking.EntityFrameworkCore;

public class EntityFrameworkCoreBTrackingDbSchemaMigrator
    : IBTrackingDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreBTrackingDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the BTrackingDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<BTrackingDbContext>()
            .Database
            .MigrateAsync();
    }
}
