using TopMove.Lettings.Context.Accounts;
using TopMove.Lettings.Shared;

namespace TopMove.Lettings.Accounts.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TopMove.Lettings.Accounts.Data.AccountsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TopMove.Lettings.Accounts.Data.AccountsContext context)
        {
            //  This method will be called after migrating to the latest version.
            //context.LandLords.Add(new LandLord(Guid.NewGuid(),new Name("Mr","Ghenghis","P", "Khan"),new Phone(),  ))
            //context.Accounts.Add(new Account(Guid.NewGuid(),))

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
