using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace TF.Abp.Blazor.Layout.BlazoriseTheme.Demo
{
    [Dependency(ReplaceServices = true)]
    public class LayoutBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "AntDesign Layout Demo";
    }
}
