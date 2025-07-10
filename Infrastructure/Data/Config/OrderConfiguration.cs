using System;
using Core.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace Infrastructure.Data.Config;

public class OrderConfiguration : IEntityTypeConfiguration<Orders>
{
    public void Configure(EntityTypeBuilder<Orders> builder)
    {
        builder.OwnsOne(x => x.shippingAddress, n => { n.WithOwner(); });
        builder.HasMany(x => x.OrderItems).WithOne().OnDelete(DeleteBehavior.Cascade);
        builder.Property(x => x.BuyerEmail).IsRequired();
        builder.Property(x => x.status).HasConversion(o => o.ToString(), o => (Status)Enum.Parse(typeof(Status), o));
        
    }
}
