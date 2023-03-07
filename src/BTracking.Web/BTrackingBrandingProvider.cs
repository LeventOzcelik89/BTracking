using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace BTracking.Web;

[Dependency(ReplaceServices = true)]
public class BTrackingBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "BTracking";
}
