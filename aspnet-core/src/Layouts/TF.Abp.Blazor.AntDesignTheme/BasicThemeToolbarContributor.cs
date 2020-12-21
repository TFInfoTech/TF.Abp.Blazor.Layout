using System.Threading.Tasks;
using TF.Abp.Blazor.Layout.AntDesignTheme.Themes.Basic;
using Volo.Abp.AspNetCore.Components.WebAssembly.Theming.Toolbars;

namespace TF.Abp.Blazor.Layout.AntDesignTheme
{
    public class BasicThemeToolbarContributor : IToolbarContributor
    {
        public Task ConfigureToolbarAsync(IToolbarConfigurationContext context)
        {
            //if (context.Toolbar.Name == StandardToolbars.Main)
            //{
            //    context.Toolbar.Items.Add(new ToolbarItem(typeof(LanguageSwitch)));
            //    context.Toolbar.Items.Add(new ToolbarItem(typeof(LoginDisplay)));
            //}

            return Task.CompletedTask;
        }
    }
}
