using System;
using System.Reflection;
using Core.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Core.Entities;
using StackExchange.Redis;
using Core.Entities.Orders;

namespace Infrastructure.Data;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Photo> Photos { get; set; }
    public virtual DbSet<Address> Addresses { get; set; }
    public virtual DbSet<Orders> Orders { get; set; }
    public virtual DbSet<OrderItem> OrderItems { get; set; }

    
    public virtual DbSet<DeliveryMethod> DeliveryMethods { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<AppUser>()
    .HasOne(u => u.Address)
    .WithOne(a => a.AppUser)
    .HasForeignKey<Address>(a => a.AppUserId);

        //modelBuilder.Entity<AppUser>().Ignore(u => u.Address);
        //modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
