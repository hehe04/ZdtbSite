namespace ZdtbSite.Core.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<ZdtbSite.Core.Infrastructure.DataContext>
    {
        public Configuration()
        {
#if DEBUG
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;//删除model实体的时候更新表需要设置
#else
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
#endif
        }

        protected override void Seed(ZdtbSite.Core.Infrastructure.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
