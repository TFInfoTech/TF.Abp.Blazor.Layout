using AntDesign.Pro.Layout;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.AspNetCore.Components.WebAssembly.Theming.Routing;
using Volo.Abp.AspNetCore.Components.WebAssembly.Theming.Toolbars;
using Volo.Abp.Modularity;


namespace TF.Abp.Blazor.Layout.AntDesignTheme
{
    [DependsOn(
        typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
        )]
    public class TFAbpBlazorAntDesignThemeModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            //context.Services.AddAntDesign();

            Configure<AbpRouterOptions>(options =>
            {
                options.AdditionalAssemblies.Add(typeof(TFAbpBlazorAntDesignThemeModule).Assembly);
            });

            Configure<AbpToolbarOptions>(options =>
            {
                options.Contributors.Add(new BasicThemeToolbarContributor());
            });


        }
    }
}
