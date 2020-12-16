using Volo.Abp.Settings;

namespace TF.Abp.Blazor.Layout.Settings
{
    public class LayoutSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(LayoutSettings.MySetting1));
        }
    }
}
