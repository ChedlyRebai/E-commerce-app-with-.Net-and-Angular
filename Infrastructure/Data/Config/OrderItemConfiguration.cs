using System;
using Core.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace Infrastructure.Data.Config;


public class OrderItemConfiguration:IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.Property(m => m.Price).HasColumnType("decimal(18,2)");
        
    }
}
