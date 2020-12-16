using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TF.Abp.Blazor.Layout.Data;
using Volo.Abp.DependencyInjection;

namespace TF.Abp.Blazor.Layout.EntityFrameworkCore
{
    public class EntityFrameworkCoreLayoutDbSchemaMigrator
        : ILayoutDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreLayoutDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the LayoutMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<LayoutMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}