using TF.Abp.Blazor.Layout.Localization;
using Volo.Abp.AspNetCore.Components;

namespace TF.Abp.Blazor.Layout.Blazor
{
    public abstract class LayoutComponentBase : AbpComponentBase
    {
        protected LayoutComponentBase()
        {
            LocalizationResource = typeof(LayoutResource);
        }
    }
}
