using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StockExchange_EGID.Server.Domain.Entities;

namespace StockExchange_EGID.Server.DataAccess.EFCore
{
    public class ApplicationContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }
        protected override async void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

           await SeedAdmins(builder);
           await SeedUsers(builder);
        }

        private async Task SeedUsers(ModelBuilder builder)
        {

            // Create a regular user
            var user = new User
            {
                Id = "d3401183-8e64-4e5b-8fbd-8d0f3ede8a75",
                UserName = "user",
                NormalizedUserName = "USER",
                Email = "regularuser@EGID.com",
                NormalizedEmail = "REGULARUSER@EGID.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Role = "User"
            };

            var password = "9y1|O7k&8"; 
            var passwordHasher = new PasswordHasher<User>();
            user.PasswordHash = passwordHasher.HashPassword(user, password);
            user.Password = user.PasswordHash;

            builder.Entity<User>().HasData(user);
        }

        private async Task SeedAdmins(ModelBuilder builder)
        {
            var admin = new User
            {
                Id = "fc40d3cd-d322-484d-9593-51dc8c6fab1b",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@EGID-manager.com",
                NormalizedEmail = "ADMIN@EGID-MANAGER.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Role = "Admin"
            };

            var password = "0H63>?vHD"; 
            var passwordHasher = new PasswordHasher<User>();
            admin.PasswordHash = passwordHasher.HashPassword(admin, password);
            admin.Password = admin.PasswordHash;
            builder.Entity<User>().HasData(admin);
        }
        public DbSet<User> users { get; set; }
    }
}
