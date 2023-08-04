using Microsoft.EntityFrameworkCore;
using TyresShopAPI.Entities.Customers;
using TyresShopAPI.Models;

namespace TyresShopAPI.Repository;

public class TyreDbContext : DbContext
{
    public TyreDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Tyre> Tyres { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<OrderTyre> OrderTyre { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Customer>()
            .HasOne(c => c.Address)
            .WithOne(a => a.Customer)
            .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<Manufacturer>().HasData(new List<Manufacturer>()
        {
            new () { Id = 1, Country = "DE", Name = "Goodyear"},
            new () { Id = 2, Country = "IT", Name = "Pirelli"},
            new () { Id = 3, Country = "FR", Name = "Michelin"},
        });
    }
}