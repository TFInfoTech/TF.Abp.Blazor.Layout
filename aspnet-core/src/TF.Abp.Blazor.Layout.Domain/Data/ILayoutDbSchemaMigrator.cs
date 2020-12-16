using System.Threading.Tasks;

namespace TF.Abp.Blazor.Layout.Data
{
    public interface ILayoutDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
