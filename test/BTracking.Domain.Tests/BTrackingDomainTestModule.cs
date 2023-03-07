using BTracking.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace BTracking;

[DependsOn(
    typeof(BTrackingEntityFrameworkCoreTestModule)
    )]
public class BTrackingDomainTestModule : AbpModule
{

}
