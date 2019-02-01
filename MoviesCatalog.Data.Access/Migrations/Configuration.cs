namespace MoviesCatalog.Data.Access.Migrations
{
    using MoviesCatalog.Data.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MoviesCatalog.Data.EF.ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MoviesCatalog.Data.EF.ApplicationContext context)
        {
            if (!context.Roles.Any())
            {
                context.Roles.Add(new Role { Name = Constants.Roles.Administrator });
                context.Roles.Add(new Role { Name = Constants.Roles.Publisher });
            }
        }
    }
}
