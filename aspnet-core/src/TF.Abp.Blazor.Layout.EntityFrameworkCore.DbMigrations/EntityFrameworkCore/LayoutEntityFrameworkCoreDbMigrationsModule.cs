using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace TF.Abp.Blazor.Layout.EntityFrameworkCore
{
    [DependsOn(
        typeof(LayoutEntityFrameworkCoreModule)
        )]
    public class LayoutEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<LayoutMigrationsDbContext>();
        }
    }
}
