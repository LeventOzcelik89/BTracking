using Volo.Abp.Modularity;

namespace BTracking;

[DependsOn(
    typeof(BTrackingApplicationModule),
    typeof(BTrackingDomainTestModule)
    )]
public class BTrackingApplicationTestModule : AbpModule
{

}
