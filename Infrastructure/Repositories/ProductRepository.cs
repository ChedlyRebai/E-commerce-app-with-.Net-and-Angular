using System;
using AutoMapper;
using Core.DTO;
using Core.Entities.Product;
using Core.Services;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace Infrastructure.Repositories;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    private readonly IMapper mapper;
    private readonly AppDbContext context;
    private readonly IImageMangeService imageMangeService;
    public ProductRepository(AppDbContext context, IMapper mapper, IImageMangeService imageMangeService) : base(context)
    {
        this.mapper = mapper;
        this.context = context;
        this.imageMangeService = imageMangeService;
    }

    public async Task<bool> AddAsync(AddProductDTo addProductDTO)
    {
        if (addProductDTO == null) return false;
        var product = mapper.Map<Product>(addProductDTO);
        await context.Products.AddAsync(product);
        await context.SaveChangesAsync();
        var ImagePath = await imageMangeService.AddImageAsync(addProductDTO.Photos, addProductDTO.Name);
        var photo = ImagePath.Select(path => new Photo()
        {
            Url = path,
            ProductId = product.Id
        }).ToList();
        await context.Photos.AddRangeAsync(photo);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<ProductDTO>> GetAllAsync(string? sort,int? categoryId,int pageSize,int pageNumber )
    {
        var query = context.Products
        .Include(m => m.Category)
        .Include(m => m.Photos)
        .AsNoTracking();

        if(categoryId.HasValue)
        {
            query=query.Where(m=>m.CategoryId==categoryId);   
        }
        if(categoryId> 0)
        {
            query=query.Where(m=>m.CategoryId==categoryId);   
        }

        if (!string.IsNullOrEmpty(sort))
        {
            query = sort switch
            {
                "PriceAsn" => query.OrderBy(m => m.NewPrice),
                "PriceDsn" => query.OrderByDescending(m => m.NewPrice),
                "NameAsn" => query.OrderBy(m => m.Name),
                "NameDsn" => query.OrderByDescending(m => m.Name),
                _ => query.OrderBy(m => m.Name),
            };
        }

        pageNumber=pageNumber > 0 ?pageNumber :1;
        pageSize=pageSize > 0 ?pageSize :10;

        query =query.Skip((pageSize) * (pageNumber -1)).Take(pageSize);
        var totalCount =await query.CountAsync();
        var totalPage =(int) totalCount/ pageSize;
        var result =mapper.Map<List<ProductDTO>>(query);
        return result;
    }

    public async Task<bool> UpdateAsync(UpdateProductDTO updateProductDTO)
    {
        if (updateProductDTO == null) return false;

        var product = await context.Products.Include(m => m.Category)
        .Include(m => m.Photos)
        .FirstOrDefaultAsync(m => m.Id == updateProductDTO.Id);

        if (product == null) return false;

        mapper.Map(updateProductDTO, product);
        var finndPhoto = await context.Photos.Where(m => m.ProductId == updateProductDTO.Id).ToListAsync();

        foreach (var item in finndPhoto)
        {
            imageMangeService.DeleteImageAsync(item.Url);
        }
        context.Photos.RemoveRange(finndPhoto);
        await context.SaveChangesAsync();
        var ImagePath = await imageMangeService.AddImageAsync(updateProductDTO.Photos, updateProductDTO.Name);
        var photo = ImagePath.Select(
            path => new Photo()
            {
                Url = path,
                ProductId = product.Id
            }
        ).ToList();
        await context.Photos.AddRangeAsync(photo);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task DeleteAsync(Product product)
    {
        var photos = await context.Photos.Where(m => m.ProductId == product.Id)
         .ToListAsync();
        foreach (var item in photos)
        {
            imageMangeService.DeleteImageAsync(item.Url);
        }
        context.Products.Remove(product);
        await context.SaveChangesAsync();
    }

}
