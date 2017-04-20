namespace LibraryRedux.Migrations
{
    using LibraryRedux.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LibraryRedux.DataContext.LibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LibraryRedux.DataContext.LibraryContext context)
        {
            //Adds books to database
            var book = new System.Collections.Generic.List<Models.BookInfo>
            {
                new Models.BookInfo{ Title = "Gone With the Wind", Author = "Mitchell", Genre = "Novel", YearPublished = 1929, DueBackDate = DateTime.Today, IsCheckedOut = true}
            };

            context.BookInfo.AddOrUpdate(a => a.Title, book.First());
            context.SaveChanges();

            //Adds customers to database
            var patron = new System.Collections.Generic.List<Models.PatronInfo>
            {
                new Models.PatronInfo{ Name = "Bernice Bladgette"}
            };

            context.PatronInfo.AddOrUpdate(a => a.Name, patron.First());
            context.SaveChanges();

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
