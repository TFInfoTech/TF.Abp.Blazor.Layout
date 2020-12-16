using Volo.Abp.Bundling;

namespace TF.Abp.Blazor.Layout.BlazoriseTheme
{
    public class BasicThemeBundleContributor : IBundleContributor
    {
        public void AddScripts(BundleContext context)
        {

        }

        public void AddStyles(BundleContext context)
        {
            context.Add("_content/TF.Abp.Blazor.Layout.BlazoriseTheme/libs/abp/css/theme.css");
        }
    }
}
