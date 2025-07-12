using NopCommerceV1.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace NopCommerceV1.Permissions;

public class NopCommerceV1PermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(NopCommerceV1Permissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(NopCommerceV1Permissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<NopCommerceV1Resource>(name);
    }
}
