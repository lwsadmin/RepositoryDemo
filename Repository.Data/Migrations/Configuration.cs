namespace Repository.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Repository.Data.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<Repository.Data.EFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Repository.Data.EFContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            List<Roles> roleList = new List<Roles> {
                 new Roles { Actions = "", RoleName = "财务部" },
                 new Roles { Actions = "", RoleName = "技术部" },
                 new Roles { Actions = "", RoleName = "人事部" },
                 new Roles { Actions = "", RoleName = "采购部" },
                 new Roles { Actions = "", RoleName = "销售部" }


            };
            if (!context.Users.Any())
            {
                context.Roles.AddRange(roleList);
            }
        }
    }
}
