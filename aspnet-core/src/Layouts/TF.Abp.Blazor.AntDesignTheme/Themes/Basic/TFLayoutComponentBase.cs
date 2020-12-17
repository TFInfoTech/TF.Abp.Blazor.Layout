using TF.Abp.Blazor.Layout.Localization;
using Volo.Abp.AspNetCore.Components;

namespace TF.Abp.Blazor.Layout.AntDesignTheme.Themes.Basic
{
    public abstract class TFLayoutComponentBase : AbpComponentBase
    {
        protected TFLayoutComponentBase()
        {
            LocalizationResource = typeof(TFBlazorLayoutResource);
        }
    }
}
