using Volo.Abp.Bundling;

namespace TF.Abp.Blazor.Layout.Blazor
{
    public class LayoutBundleContributor : IBundleContributor
    {
        public void AddScripts(BundleContext context)
        {
        }

        public void AddStyles(BundleContext context)
        {
            context.Add("main.css");
        }
    }
}
