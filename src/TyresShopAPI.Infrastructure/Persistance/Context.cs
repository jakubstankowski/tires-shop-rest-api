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

            modelBuilder.Entity<Tyre>().HasData(new List<Tyre>()
            {
                new Tyre() {Id = 1, Model = "P2", Price = 125.50M, ProductionYear = 2020, SizeDiameter = 225, SizeProfile = 16, SizeWidth = 50, ProducerId = 1, TyresType = 0},
                new Tyre() {Id = 2, Model = "P3", Price = 125.50M, ProductionYear = 2021, SizeDiameter = 225, SizeProfile = 16, SizeWidth = 50, ProducerId = 1, TyresType = 0},
                new Tyre() {Id = 3, Model = "P4", Price = 125.50M, ProductionYear = 2022, SizeDiameter = 225, SizeProfile = 16, SizeWidth = 50, ProducerId = 1, TyresType = 0},
            });

            modelBuilder.Entity<Tyre>().HasData(new List<Address>()
            {
                new Address() {Id = 1, City = "Gdansk", HomeNumber = 3, PostalCode = "00-000", Street = "Grodzka"},
                new Address() {Id = 2, City = "Warszawa", HomeNumber = 3, PostalCode = "00-000", Street = "Grodzka"},
                new Address() {Id = 3, City = "Radom", HomeNumber = 3, PostalCode = "00-000", Street = "Grodzka"}
            });

            modelBuilder.Entity<Tyre>().HasData(new List<Customer>()
            {
                new Customer() {Id = 1, FirstName = "Jakub", LastName = "Stankowski"},
                new Customer() {Id = 2, FirstName = "Jan", LastName = "Nowicki"},
                new Customer() {Id = 3, FirstName = "Maryla", LastName = "Rodowicz"}
            });



        }
    }
}
