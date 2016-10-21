namespace S00153208Clubs.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<S00153208Clubs.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(S00153208Clubs.Models.ApplicationDbContext context)
        {

            var manager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context)
                );

            PasswordHasher pass = new PasswordHasher();

            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole {
                    Name = "Admin"
                });
            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole
                {
                    Name = "ClubAdmin"
                });
            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole
                {
                    Name = "Member"
                });


            context.Users.AddOrUpdate(n => n.UserName,
                new ApplicationUser {
                    StudentID = "S0000123",
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    EmailConfirmed = true,
                    Joined = DateTime.Now,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PasswordHash = pass.HashPassword("Password01.")
                });

            context.Users.AddOrUpdate(n => n.UserName,
                new ApplicationUser
                {
                    StudentID = "S0000124",
                    UserName = "clubadmin@gmail.com",
                    Email = "clubadmin@gmail.com",
                    EmailConfirmed = true,
                    Joined = DateTime.Now,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PasswordHash = pass.HashPassword("Password01.")
                });

            context.Users.AddOrUpdate(n => n.UserName,
                new ApplicationUser
                {
                    StudentID = "S0000125",
                    UserName = "member@gmail.com",
                    Email = "member@gmail.com",
                    EmailConfirmed = true,
                    Joined = DateTime.Now,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PasswordHash = pass.HashPassword("Password01.")
                });

            context.SaveChanges();

            /*ApplicationUser admin = manager.FindByEmail("admin@gmail.com");
            ApplicationUser clubadmin = manager.FindByEmail("clubadmin@gmail.com");
            ApplicationUser member = manager.FindByEmail("member@gmail.com");

            if (admin != null)
            {
                manager.AddToRoles(admin.Id, new string[] { "Admin", "ClubAdmin", "Member" });
                manager.AddToRoles(clubadmin.Id, new string[] { "ClubAdmin", "Member" });
                manager.AddToRole(member.Id, "Member");
            }*/


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
