using Microsoft.EntityFrameworkCore;
using System;
using YounicornApp.Core.Entities;

namespace YounicornApp.Infrastructure.Data.Seeds
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
            new Role { Id = 1, Name = "Admin", IsActive = true, RedirectUrl = "/Provider/Index", CreatedBy = 1, CreatedDate = DateTime.UtcNow },
            new Role { Id = 2, Name = "Member", IsActive = true, RedirectUrl = "", CreatedBy = 1, CreatedDate = DateTime.UtcNow }
            );

            modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Firstname = "admin", Email = "admin@younicorn.com", Lastname = "admin", Phone = "12345678", Username = "younicorn", Password = "YouYou99!", IsActive = true, RoleId = 1, CreatedBy = 1, CreatedDate = DateTime.UtcNow },
            new User { Id = 2, Firstname = "user", Email = "testuser@younicorn.com", Lastname = "user", Phone = "123456789", Username = "user", Password = "user", IsActive = true, RoleId = 2, CreatedBy = 1, CreatedDate = DateTime.UtcNow }

            );
        }
    }
}
