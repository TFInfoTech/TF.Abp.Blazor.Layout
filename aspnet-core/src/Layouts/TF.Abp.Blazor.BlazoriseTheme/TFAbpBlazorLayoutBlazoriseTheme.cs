using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.AspNetCore.Components.WebAssembly.Theming.Routing;
using Volo.Abp.AspNetCore.Components.WebAssembly.Theming.Toolbars;
using Volo.Abp.Modularity;


namespace TF.Abp.Blazor.Layout.BlazoriseTheme
{
    [DependsOn(
        typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
        )]
    public class TFAbpBlazorLayoutBlazoriseThemeModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            //context.Services.AddAntDesign();

            Configure<AbpRouterOptions>(options =>
            {
                options.AdditionalAssemblies.Add(typeof(TFAbpBlazorLayoutBlazoriseThemeModule).Assembly);
            });

            Configure<AbpToolbarOptions>(options =>
            {
                options.Contributors.Add(new BasicThemeToolbarContributor());
            });


        }
    }
}
