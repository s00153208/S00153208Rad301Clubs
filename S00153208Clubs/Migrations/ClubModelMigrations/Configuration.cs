namespace S00153208Clubs.Migrations.ClubModelMigrations
{
    using Models.ClubModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<S00153208Clubs.Models.ClubContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ClubModelMigrations";
        }

        protected override void Seed(S00153208Clubs.Models.ClubContext context)
        {

            context.Clubs.AddOrUpdate(c => c.ClubName,
                new Club
                {
                    ClubName = "Awesome club mate",
                    CreationDate = DateTime.Now,
                });

            context.Clubs.AddOrUpdate(c => c.ClubName,
                new Club
                {
                    ClubName = "Not a bad club dude",
                    CreationDate = DateTime.Now,
                });

        }
    }
}
