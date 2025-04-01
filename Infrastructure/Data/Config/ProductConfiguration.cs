using System;
using Core.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x=>x.Name).IsRequired().HasMaxLength(30);
        builder.Property(x=>x.Description).IsRequired();
        builder.Property(x=>x.Price).IsRequired().HasColumnType("decimal(18,2)");
    }
}
