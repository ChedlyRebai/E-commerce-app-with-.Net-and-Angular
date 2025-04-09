using System;
using Core.DTO;
using Core.Entities.Product;
using Core.Interfaces;
using Infrastructure.Shared;

namespace Infrastructure.Repositories;

public interface IProductRepository:IGenericRepository<Product>
{
    Task<IEnumerable<ProductDTO>> GetAllAsync(ProductParam productParam);
    public Task<bool> AddAsync(AddProductDTo addProductDTO);
    Task<bool> UpdateAsync(UpdateProductDTO updateProductDTO);

    Task DeleteAsync(Product product);
}
