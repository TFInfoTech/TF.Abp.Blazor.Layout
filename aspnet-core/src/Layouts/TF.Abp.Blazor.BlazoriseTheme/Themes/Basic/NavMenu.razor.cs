using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Volo.Abp.UI.Navigation;

namespace TF.Abp.Blazor.Layout.BlazoriseTheme.Themes.Basic
{
    public partial class NavMenu
    {
        [Inject]
        protected IMenuManager MenuManager { get; set; }

        protected ApplicationMenu Menu { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Menu = await MenuManager.GetAsync(StandardMenus.Main);
        }
    }
}
