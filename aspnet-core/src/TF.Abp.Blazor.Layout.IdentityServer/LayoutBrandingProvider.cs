using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace TF.Abp.Blazor.Layout
{
    [Dependency(ReplaceServices = true)]
    public class LayoutBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Layout";
    }
}
