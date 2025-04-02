using System;
using Core.Entities.Product;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryReppository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
        
    }
}
