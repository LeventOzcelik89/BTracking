using System;
using System.Collections.Generic;
using System.Text;
using BTracking.Localization;
using Volo.Abp.Application.Services;

namespace BTracking;

/* Inherit your application services from this class.
 */
public abstract class BTrackingAppService : ApplicationService
{
    protected BTrackingAppService()
    {
        LocalizationResource = typeof(BTrackingResource);
    }
}
