using Logiswift.TODOApp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Logiswift.TODOApp.Permissions;

public class TODOAppPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var LogiswiftTODOAppGroup = context.AddGroup(TODOAppPermissions.GroupName);
        //Define your own permissions here. Example:
        var itemsPermission = LogiswiftTODOAppGroup.AddPermission(TODOAppPermissions.Items.Default, L("Permission:Items"));
        itemsPermission.AddChild(TODOAppPermissions.Items.Create, L("Permission:Items.Create"));
        itemsPermission.AddChild(TODOAppPermissions.Items.Edit, L("Permission:Items.Edit"));
        itemsPermission.AddChild(TODOAppPermissions.Items.Delete, L("Permission:Items.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<TODOAppResource>(name);
    }
}
