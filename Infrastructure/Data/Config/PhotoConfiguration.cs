using System;
using Core.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config;

public class PhotoConfiguration: IEntityTypeConfiguration<Photo>
{
    public void Configure(EntityTypeBuilder<Photo> builder)
    {
        builder.HasData(new Photo {
            Id =1,
            ProductId = 1,
            Url = "https://example.com/photo1.jpg",
        }); 
    }

}
