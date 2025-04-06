using System;
using AutoMapper;
using Core.DTO;
using Core.Entities.Product;
using Core.Services;
using Infrastructure.Data;
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
}
