using System;
using Core.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasMaxLength(30);
        builder.Property(x=>x.Id).IsRequired();
        /*  builder.HasData(
            new Category
            {
                Id = 2,
                Name = "Category 1",
                Description = "Description for Category 1"
            }
        );  */
    }
}
