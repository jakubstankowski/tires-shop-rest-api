using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TyresShopAPI.Domain.Entities;
using TyresShopAPI.Domain.Entities.Cart;
using TyresShopAPI.Domain.Entities.Customers;
using TyresShopAPI.Domain.Entities.OrderAggregate;

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

        public DbSet<CustomerAddress> Adresses { get; set; } = null!;

        public DbSet<Order> Orders { get; set; } = null!;

        public DbSet<OrderItem> OrderItems { get; set; } = null!;

        public DbSet<CustomerCart> CustomerCarts { get; set; } = null!;

        public DbSet<CartItem> CartItems { get; set; } = null!;

        public DbSet<DeliveryMethod> DeliveryMethods { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
                 .HasOne<CustomerAddress>(a => a.Address)
                 .WithOne(cs => cs.Customer)
                 .HasForeignKey<CustomerAddress>(ca => ca.CustomerId);

            modelBuilder.Entity<Producer>().HasData(new List<Producer>()
            {
                new Producer() {Id = 1, Country = "Germany", Name = "Pirelli"},
                new Producer() {Id = 2, Country = "China", Name = "Michellin"},
                new Producer() {Id = 3, Country = "Japan", Name = "Goodyear"}
            });

            modelBuilder.Entity<Tyre>().HasData(new List<Tyre>()
            {
                new Tyre() {Id = 1, Model = "P2", Price = 125.50M, ProductionYear = 2020, SizeDiameter = 225, SizeProfile = 16, SizeWidth = 50, ProducerId = 1, TyresType = 0},
                new Tyre() {Id = 2, Model = "P3", Price = 125.50M, ProductionYear = 2021, SizeDiameter = 225, SizeProfile = 16, SizeWidth = 50, ProducerId = 1, TyresType = 0},
                new Tyre() {Id = 3, Model = "P4", Price = 125.50M, ProductionYear = 2022, SizeDiameter = 225, SizeProfile = 16, SizeWidth = 50, ProducerId = 1, TyresType = 0},
            });

            modelBuilder.Entity<Customer>().HasData(new List<Customer>()
            {
                new Customer() {Id = 1, FirstName = "Jakub", LastName = "Stankowski"},
                new Customer() {Id = 2, FirstName = "Jan", LastName = "Nowicki"},
                new Customer() {Id = 3, FirstName = "Maryla", LastName = "Rodowicz"}
            });

            modelBuilder.Entity<CustomerAddress>().HasData(new List<CustomerAddress>()
            {
                new CustomerAddress() {Id = 1, City = "Gdansk", HomeNumber = 3, PostalCode = "00-000", Street = "Grodzka", CustomerId = 1},
                new CustomerAddress() {Id = 2, City = "Warszawa", HomeNumber = 3, PostalCode = "00-000", Street = "Grodzka", CustomerId = 2},
                new CustomerAddress() {Id = 3, City = "Radom", HomeNumber = 3, PostalCode = "00-000", Street = "Grodzka", CustomerId = 3}
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
