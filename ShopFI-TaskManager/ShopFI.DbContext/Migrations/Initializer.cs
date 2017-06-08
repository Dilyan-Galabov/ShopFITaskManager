using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ShopFI.Common;
using ShopFI.Entities.Common;
using ShopFI.Entities.Models;
using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace ShopFI.DbContext.Migrations
{
    internal class Initializer
    {
        internal static void SeedRoles(ApplicationDbContext context)
        {
            string[] roles =
            {
                "Moderator",
                "Manager",
                "Student",
                "Guest"
            };

            foreach (var role in roles)
            {
                var roleStore = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                if (!context.Roles.Any(r => r.Name == role))
                {
                    roleStore.Create(new IdentityRole(role));
                }
            }
        }

        internal static void SeedUsers(ApplicationDbContext context)
        {
            string userName = "Admin";
            string admin = "Admin";
            var userRoleAdmin = new IdentityRole() { Id = new CustomId().ToString(), Name = admin };
            context.Roles.Add(userRoleAdmin);

            var hasher = new PasswordHasher();

            var user = new User
            {
                UserName = userName,
                PasswordHash = hasher.HashPassword("admin123456"),
                Email = "admin@admin.com",
                EmailConfirmed = true,
                SecurityStamp = new CustomId().ToString()
            };
            user.Roles.Add(new IdentityUserRole { RoleId = userRoleAdmin.Id, UserId = user.Id });
            context.Users.Add(user);
        }



        internal static void SeedCategories(ApplicationDbContext context)
        {
            context.Categories.AddOrUpdate
                (
                    c => c.Name,
                    new Category("Cars"),
                    new Category("Sport/Hobbies/Books"),
                    new Category("Animals"),
                    new Category("Home and garden"),
                    new Category("Mode"),
                    new Category("For baby and child"),
                    new Category("Work"),
                    new Category("Electronics")
                );
        }




    }
}