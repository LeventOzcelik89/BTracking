using BTracking.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace BTracking.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class BTrackingController : AbpControllerBase
{
    protected BTrackingController()
    {
        LocalizationResource = typeof(BTrackingResource);
    }
}
