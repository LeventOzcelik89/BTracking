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

        var dataSourceCity = myGroup.AddPermission(BTrackingPermissions.City.Default, L("Permission:DataSources"));
        dataSourceCity.AddChild(BTrackingPermissions.City.Create, L("Permission:Create"));
        dataSourceCity.AddChild(BTrackingPermissions.City.Edit, L("Permission:Edit"));
        dataSourceCity.AddChild(BTrackingPermissions.City.Delete, L("Permission:Delete"));

        var dataSourceTown = myGroup.AddPermission(BTrackingPermissions.Town.Default, L("Permission:DataSources"));
        dataSourceTown.AddChild(BTrackingPermissions.Town.Create, L("Permission:Create"));
        dataSourceTown.AddChild(BTrackingPermissions.Town.Edit, L("Permission:Edit"));
        dataSourceTown.AddChild(BTrackingPermissions.Town.Delete, L("Permission:Delete"));

        var dataSourceFinance = myGroup.AddPermission(BTrackingPermissions.Finance.Default, L("Permission:DataSources"));
        dataSourceFinance.AddChild(BTrackingPermissions.Finance.Create, L("Permission:Create"));
        dataSourceFinance.AddChild(BTrackingPermissions.Finance.Edit, L("Permission:Edit"));
        dataSourceFinance.AddChild(BTrackingPermissions.Finance.Delete, L("Permission:Delete"));


        //Define your own permissions here. Example:
        //myGroup.AddPermission(BTrackingPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BTrackingResource>(name);
    }
}
