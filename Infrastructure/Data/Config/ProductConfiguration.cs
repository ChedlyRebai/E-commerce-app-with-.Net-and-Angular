using System;
using Core.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Infrastructure.Data.Config;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasMaxLength(30);
        builder.Property(x => x.Description).IsRequired();
        builder.Property(x => x.NewPrice).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(x => x.OldPrice).IsRequired().HasColumnType("decimal(18,2)");
          /*builder.HasData(
             new Product{
                 Id = 1,
                 Name = "Product 1",
                 Description = "Description 1",
                 Price = 10000,
                 Stock = 10,
                 CategoryId = 2
             }
         );*/
    }
}
