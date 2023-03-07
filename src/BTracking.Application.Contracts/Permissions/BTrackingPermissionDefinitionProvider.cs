using BTracking.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace BTracking.Permissions;

public class BTrackingPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(BTrackingPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(BTrackingPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BTrackingResource>(name);
    }
}
