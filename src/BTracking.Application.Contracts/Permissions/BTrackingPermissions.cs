namespace BTracking.Permissions;

public static class BTrackingPermissions
{
    public const string GroupName = "BTracking";

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";

    public class Country
    {
        public const string Default = GroupName + ".Country";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
    public class City
    {
        public const string Default = GroupName + ".City";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }


}
