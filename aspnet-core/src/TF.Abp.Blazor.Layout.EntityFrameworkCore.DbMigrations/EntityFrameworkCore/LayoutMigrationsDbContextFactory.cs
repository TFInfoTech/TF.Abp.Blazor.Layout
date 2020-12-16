using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TF.Abp.Blazor.Layout.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class LayoutMigrationsDbContextFactory : IDesignTimeDbContextFactory<LayoutMigrationsDbContext>
    {
        public LayoutMigrationsDbContext CreateDbContext(string[] args)
        {
            LayoutEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<LayoutMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new LayoutMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../TF.Abp.Blazor.Layout.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
