using TF.Abp.Blazor.Layout.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace TF.Abp.Blazor.Layout.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(LayoutEntityFrameworkCoreDbMigrationsModule),
        typeof(LayoutApplicationContractsModule)
        )]
    public class LayoutDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
