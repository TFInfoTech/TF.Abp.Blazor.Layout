using TF.Abp.Blazor.Layout.Localization;
using Volo.Abp.AspNetCore.Components;

namespace TF.Abp.Blazor.Layout.BlazoriseTheme.Demo
{
    public abstract class DemoLayoutComponentBase : AbpComponentBase
    {
        protected DemoLayoutComponentBase()
        {
            LocalizationResource = typeof(LayoutResource);
        }
    }
}
