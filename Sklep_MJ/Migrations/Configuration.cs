namespace Sklep_MJ.Migrations
{
    using Sklep_MJ.DAL;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Sklep_MJ.DAL.CoursesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Sklep_MJ.DAL.CoursesContext";
        }

        protected override void Seed(Sklep_MJ.DAL.CoursesContext context)
        {
            //CoursesInitializer.SeedCoursesData(context);
            CoursesInitializer.SeedUsers(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
