using BTracking.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace BTracking.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(BTrackingEntityFrameworkCoreModule),
    typeof(BTrackingApplicationContractsModule)
    )]
public class BTrackingDbMigratorModule : AbpModule
{

}
