using BTracking.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace BTracking.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class BTrackingPageModel : AbpPageModel
{
    protected BTrackingPageModel()
    {
        LocalizationResourceType = typeof(BTrackingResource);
    }
}
