using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace TF.Abp.Blazor.Layout.Data
{
    /* This is used if database provider does't define
     * ILayoutDbSchemaMigrator implementation.
     */
    public class NullLayoutDbSchemaMigrator : ILayoutDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}