using Volo.Abp.Modularity;

namespace TF.Abp.Blazor.Layout
{
    [DependsOn(
        typeof(LayoutApplicationModule),
        typeof(LayoutDomainTestModule)
        )]
    public class LayoutApplicationTestModule : AbpModule
    {

    }
}