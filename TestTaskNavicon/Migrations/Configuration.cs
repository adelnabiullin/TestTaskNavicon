namespace TestTaskNavicon.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<TestTaskNavicon.Models.ContactDBContext>
    {
        // проект тестовый и маленький, поэтому достаточно возможности обновл€ть Ѕƒ в одну команду
        // при бќльших размерах, конечно, нужны миграции
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "TestTaskNavicon.Models.ContactDBContext";
        }

        protected override void Seed(TestTaskNavicon.Models.ContactDBContext context)
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
