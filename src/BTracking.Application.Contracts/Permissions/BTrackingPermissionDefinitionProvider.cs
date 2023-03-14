using BTracking.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace BTracking.Permissions;

public class BTrackingPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(BTrackingPermissions.GroupName);

        var dataSourceCountry = myGroup.AddPermission(BTrackingPermissions.Country.Default, L("Permission:DataSources"));
        dataSourceCountry.AddChild(BTrackingPermissions.Country.Create, L("Permission:Create"));
        dataSourceCountry.AddChild(BTrackingPermissions.Country.Edit, L("Permission:Edit"));
        dataSourceCountry.AddChild(BTrackingPermissions.Country.Delete, L("Permission:Delete"));

        var dataSourceCity = myGroup.AddPermission(BTrackingPermissions.City.Default, L("Permission:DataSourceQueries"));
        dataSourceCity.AddChild(BTrackingPermissions.City.Create, L("Permission:Create"));
        dataSourceCity.AddChild(BTrackingPermissions.City.Edit, L("Permission:Edit"));
        dataSourceCity.AddChild(BTrackingPermissions.City.Delete, L("Permission:Delete"));

        //Define your own permissions here. Example:
        //myGroup.AddPermission(BTrackingPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BTrackingResource>(name);
    }
}
