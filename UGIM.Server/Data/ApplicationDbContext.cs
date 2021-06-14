using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UGIM.Server.Models;

namespace UGIM.Server.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            string ADMIN_ID = Guid.NewGuid().ToString();
            string ROLE_ID = Guid.NewGuid().ToString();

            //seed admin role
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "Admin",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });

            //create user
            var appUser = new AppUser
            {
                Id = ADMIN_ID,
                Email = "raminquliyev00@gmail.com",
                EmailConfirmed = true,
                NormalizedEmail = "RAMINQULIYEV00@GMAIL.COM",
                FirstName = "Ramin",
                LastName = "Guliyev",
                UserName = "RAMINQULIYEV00@GMAIL.COM",
                Title = "Admin"
            };

            //set user password
            PasswordHasher<AppUser> ph = new PasswordHasher<AppUser>();
            appUser.PasswordHash = ph.HashPassword(appUser, "Ra.min12");


            //seed user
            builder.Entity<AppUser>().HasData(appUser);

            //set user role to admin
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
            base.OnModelCreating(builder);
        }
    }
}
