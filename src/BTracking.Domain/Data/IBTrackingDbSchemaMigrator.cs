using System.Threading.Tasks;

namespace BTracking.Data;

public interface IBTrackingDbSchemaMigrator
{
    Task MigrateAsync();
}
