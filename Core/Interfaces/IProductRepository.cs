using System;
using Core.DTO;
using Core.Entities.Product;
using Core.Interfaces;

namespace Infrastructure.Repositories;

public interface IProductRepository:IGenericRepository<Product>
{
    Task<IEnumerable<ProductDTO>> GetAllAsync(string sort);
    public Task<bool> AddAsync(AddProductDTo addProductDTO);
    Task<bool> UpdateAsync(UpdateProductDTO updateProductDTO);

    Task DeleteAsync(Product product);
}
