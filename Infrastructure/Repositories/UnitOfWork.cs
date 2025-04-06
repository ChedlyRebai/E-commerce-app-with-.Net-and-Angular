using System;
using AutoMapper;
using Core.Interfaces;
using Core.Services;
using Infrastructure.Data;


namespace Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly IImageMangeService _imageMangeService;
    public ICategoryReppository CategoryReppository {get; }

    public IProductRepository ProductRepository {get; }

    public IPhotoRepository PhotoRepository {get; }
    public UnitOfWork(AppDbContext context,IMapper mapper,IImageMangeService imageMangeService)
    {
        _mapper=mapper;
        _imageMangeService=imageMangeService;
        _context = context;
        CategoryReppository = new CategoryRepository(_context);
        ProductRepository =new ProductRepository(_context,_mapper,_imageMangeService);
        PhotoRepository = new PhotoRepository(_context);
       

    }
}
