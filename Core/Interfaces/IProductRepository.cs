using System;
using Core.DTO;
using Core.Entities.Product;
using Core.Interfaces;

namespace Infrastructure.Repositories;

public interface IProductRepository:IGenericRepository<Product>
{
    public Task<bool> AddAsync(AddProductDTo addProductDTO);
    Task<bool> UpdateAsync(UpdateProductDTO updateProductDTO);
}
