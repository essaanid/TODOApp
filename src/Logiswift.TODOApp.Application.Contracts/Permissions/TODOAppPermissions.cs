namespace Logiswift.TODOApp.Permissions;

public static class TODOAppPermissions
{
    public const string GroupName = "TODOApp";

    //Add your own permission names. Example:
    public static class Items
    {
        public const string Default = GroupName + ".Items";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}
