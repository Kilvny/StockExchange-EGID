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
           await SeedStocks(builder);
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

        private async Task SeedStocks(ModelBuilder builder)
        {
            // Define the symbols, names, and prices
            var stockData = new[]
            {
                new { Symbol = "AAPL", Name = "Apple Inc.", Price = 150.25m },
                new { Symbol = "GOOGL", Name = "Alphabet Inc.", Price = 2800.45m },
                new { Symbol = "MSFT", Name = "Microsoft Corporation", Price = 300.00m },
                new { Symbol = "AMZN", Name = "Amazon.com Inc.", Price = 3300.00m },
                new { Symbol = "TSLA", Name = "Tesla Inc.", Price = 800.00m }
            };

            // Seed the stocks table with the provided data
            foreach (var stock in stockData)
            {
                var newStock = new Stock
                {
                    Id = Guid.NewGuid(),
                    Symbol = stock.Symbol,
                    Name = stock.Name,
                    Price = stock.Price
                };
                builder.Entity<Stock>().HasData(newStock);
            }

        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockHistory>  StocksHistories { get; set; }
    }
}
