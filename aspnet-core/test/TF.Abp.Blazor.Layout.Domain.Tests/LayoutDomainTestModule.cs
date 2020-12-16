using TF.Abp.Blazor.Layout.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace TF.Abp.Blazor.Layout
{
    [DependsOn(
        typeof(LayoutEntityFrameworkCoreTestModule)
        )]
    public class LayoutDomainTestModule : AbpModule
    {

    }
}