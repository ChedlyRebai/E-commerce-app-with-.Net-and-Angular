using System;
using AutoMapper;
using Core.Interfaces;
using Core.Services;
using Infrastructure.Data;
using Infrastructure.Repositories.Service;
using StackExchange.Redis;


namespace Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly IImageMangeService _imageMangeService;
    private readonly IConnectionMultiplexer _redis;
    public ICategoryReppository CategoryReppository {get; }

    public IProductRepository ProductRepository {get; }

    public IPhotoRepository PhotoRepository {get; }

    public ICustomerBasketRepository CustomerBasket {get; }
    public UnitOfWork(AppDbContext context, IMapper mapper, IImageMangeService imageMangeService, IConnectionMultiplexer redis)
    {
        _mapper = mapper;
        _imageMangeService = imageMangeService;
        _context = context;
        _redis = redis;
        CategoryReppository = new CategoryRepository(_context);
        ProductRepository = new ProductRepository(_context, _mapper, _imageMangeService);
        PhotoRepository = new PhotoRepository(_context);
        CustomerBasket = new CustomerBasketRepository(_redis);

    
    }
}
