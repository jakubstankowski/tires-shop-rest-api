using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TyresShopAPI.Domain.Entities;
using TyresShopAPI.Domain.Entities.Cart;
using TyresShopAPI.Domain.Entities.Customers;
using TyresShopAPI.Domain.Entities.OrderAggregate;

namespace TyresShopAPI.Infrastructure.Persistance
{
    public class Context : IdentityDbContext<Customer>
    {
        public Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Tyre> Tyres { get; set; } = null!;

        public DbSet<Producer> Producers { get; set; } = null!;

        public DbSet<CustomerAddress> CustomerAddresses { get; set; } = null!;

        public DbSet<Order> Orders { get; set; } = null!;

        public DbSet<OrderItem> OrderItems { get; set; } = null!;

        public DbSet<CustomerCart> CustomerCarts { get; set; } = null!;

        public DbSet<CartItem> CartItems { get; set; } = null!;

        public DbSet<DeliveryMethod> DeliveryMethods { get; set; } = null!;

        public DbSet<OrderDelivery> OrderDeliveries { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
                 .HasOne<CustomerAddress>(a => a.Address)
                 .WithOne(cs => cs.Customer)
                 .HasForeignKey<CustomerAddress>(ca => ca.CustomerId);

            modelBuilder.Entity<Customer>()
                 .HasOne<CustomerCart>(a => a.CustomerCart)
                 .WithOne(cs => cs.Customer)
                 .HasForeignKey<CustomerCart>(ca => ca.CustomerId);

            modelBuilder.Entity<CartItem>()
            .Property(o => o.TotalValue)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<DeliveryMethod>()
            .Property(o => o.Price)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Order>()
            .Property(o => o.Subtotal)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OrderItem>()
            .Property(o => o.Price)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Tyre>()
            .Property(o => o.Price)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Producer>().HasData(new List<Producer>()
            {
                new Producer() {Id = 1, Country = "Germany", Name = "Pirelli"},
                new Producer() {Id = 2, Country = "China", Name = "Michellin"},
                new Producer() {Id = 3, Country = "Japan", Name = "Goodyear"}
            });

            modelBuilder.Entity<Tyre>().HasData(new List<Tyre>()
            {
                new Tyre() {Id = 1, Model = "P2", Price = 125.50M, ProductionYear = 2020, SizeDiameter = 225, SizeProfile = 16, SizeWidth = 50, ProducerId = 1, TyresType = 0, IsAvailable = true},
                new Tyre() {Id = 2, Model = "P3", Price = 125.50M, ProductionYear = 2021, SizeDiameter = 225, SizeProfile = 16, SizeWidth = 50, ProducerId = 1, TyresType = 0, IsAvailable = true},
                new Tyre() {Id = 3, Model = "P4", Price = 125.50M, ProductionYear = 2022, SizeDiameter = 225, SizeProfile = 16, SizeWidth = 50, ProducerId = 1, TyresType = 0, IsAvailable = true},
            });

            modelBuilder.Entity<DeliveryMethod>().HasData(new List<DeliveryMethod>()
            {
                new DeliveryMethod() {Id = 1, Name = "Kurier DPD", DeliveryTime = "24h", Price = 15m},
                new DeliveryMethod() {Id = 2, Name = "Kurier DHL", DeliveryTime = "24h", Price = 15m},
                new DeliveryMethod() {Id = 3, Name = "Paczkomat", DeliveryTime = "24h", Price = 10m},
            });

        }
    }
}
