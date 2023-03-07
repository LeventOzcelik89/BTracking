using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace BTracking.Data;

/* This is used if database provider does't define
 * IBTrackingDbSchemaMigrator implementation.
 */
public class NullBTrackingDbSchemaMigrator : IBTrackingDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
