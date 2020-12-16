using Volo.Abp.Bundling;

namespace TF.Abp.Blazor.Layout.AntDesignTheme
{
    public class BasicThemeBundleContributor : IBundleContributor
    {
        public void AddScripts(BundleContext context)
        {

        }

        public void AddStyles(BundleContext context)
        {
            context.Add("_content/TF.Abp.Blazor.Layout.AntDesignTheme/libs/abp/css/theme.css");
            context.Add("_content/TF.Abp.Blazor.Layout.AntDesignTheme/libs/tf/css/compatible.css");
            context.Add("_content/AntDesign/css/ant-design-blazor.css");
            context.Add("_content/AntDesign.Pro.Layout/css/ant-design-pro-layout-blazor.css");
            context.Add("_content/AntDesign/js/ant-design-blazor.js");
        }
    }
}
