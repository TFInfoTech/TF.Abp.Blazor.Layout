using AntDesign;
using Localization.Resources.AbpUi;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace TF.Abp.Blazor.Layout.AntDesignTheme.Themes.Basic
{
    public partial class AvatarDropdown
    {
        [Inject] IStringLocalizer<AbpUiResource> L { get; set; }

        [Parameter] public string Avatar { get; set; }
        [Parameter] public string Name { get; set; }
        [Parameter] public EventCallback<MenuItem> OnItemSelected { get; set; }
    }
}