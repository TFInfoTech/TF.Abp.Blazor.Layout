using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace TF.Abp.Blazor.Layout.EntityFrameworkCore
{
    public static class LayoutDbContextModelCreatingExtensions
    {
        public static void ConfigureLayout(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(LayoutConsts.DbTablePrefix + "YourEntities", LayoutConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}