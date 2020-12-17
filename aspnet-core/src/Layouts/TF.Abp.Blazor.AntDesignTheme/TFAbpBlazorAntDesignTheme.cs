using AntDesign.Pro.Layout;
using Microsoft.Extensions.DependencyInjection;
using TF.Abp.Blazor.Layout.Localization;
using TF.Abp.Blazor.Layout.Shared;
using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.AspNetCore.Components.WebAssembly.Theming.Routing;
using Volo.Abp.AspNetCore.Components.WebAssembly.Theming.Toolbars;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace TF.Abp.Blazor.Layout.AntDesignTheme
{
    [DependsOn(
        typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule),
        typeof(TFBlazorLayoutSharedModule)
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

            //Configure<AbpVirtualFileSystemOptions>(options =>
            //{
            //    // "YourRootNameSpace" is the root namespace of your project. It can be empty if your root namespace is empty.
            //    options.FileSets.AddEmbedded<TFAbpBlazorAntDesignThemeModule>();
            //});

            //Configure<AbpLocalizationOptions>(options =>
            //{
            //    //Define a new localization resource (TestResource)
            //    options.Resources
            //        .Add<TFBlazorLayoutResource>("en")
            //        .AddVirtualJson("/Localization/TFBlazorLayout");
            //});
        }
    }
}
