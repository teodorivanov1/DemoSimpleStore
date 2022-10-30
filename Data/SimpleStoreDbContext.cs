using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimpleStoreWeb.Data.Entities;
using SimpleStoreWeb.Data.EntityConfigurations;
using System;

namespace SimpleStoreWeb.Data
{
    public class SimpleStoreDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public const string DefaultSchema = "public";
        private readonly IConfiguration configuration;

        public SimpleStoreDbContext() { }

        public SimpleStoreDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("ConnectionString"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            ArgumentNullException.ThrowIfNull(nameof(builder));
            builder.ApplyConfiguration(new Categories());
            builder.ApplyConfiguration(new Products());
            builder.ApplyConfiguration(new Orders());
            builder.ApplyConfiguration(new OrderItems());

            base.OnModelCreating(builder);
        }
    }
}
