using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace TF.Abp.Blazor.Layout.Blazor
{
    [Dependency(ReplaceServices = true)]
    public class LayoutBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Layout";
    }
}
