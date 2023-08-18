using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TyresShopAPI.Domain.Entities;
using TyresShopAPI.Domain.Entities.Cart;
using TyresShopAPI.Domain.Entities.Customers;

namespace TyresShopAPI.Infrastructure.Persistance
{
    public class Context : IdentityDbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Tyre> Tyres { get; set; } = null!;

        public DbSet<Producer> Producers { get; set; } = null!;

        public DbSet<Customer> Customers { get; set; } = null!;

        public DbSet<Address> Adresses { get; set; } = null!;

        public DbSet<Cart> Carts { get; set; } = null!;

        public DbSet<CartItem> CartItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Address)
                .WithOne(a => a.Customer);

            modelBuilder.Entity<Producer>().HasData(new List<Producer>()
            {
                new Producer() {Id = 1, Country = "Germany", Name = "Pirelli"},
                new Producer() {Id = 2, Country = "China", Name = "Michellin"},
                new Producer() {Id = 3, Country = "Japan", Name = "Goodyear"}
            });

        }
    }
}
