using TF.Abp.Blazor.Layout.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace TF.Abp.Blazor.Layout.Permissions
{
    public class LayoutPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(LayoutPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(LayoutPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<LayoutResource>(name);
        }
    }
}
