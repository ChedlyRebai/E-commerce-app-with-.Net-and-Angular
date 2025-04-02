using System;
using Core.Interfaces;
using Infrastructure.Data;


namespace Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public ICategoryReppository CategoryReppository {get; }

    public IProductRepository ProductRepository {get; }

    public IPhotoRepository PhotoRepository {get; }
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        CategoryReppository = new CategoryRepository(_context);
        ProductRepository =new ProductRepository(_context);
        PhotoRepository = new PhotoRepository(_context);

    }
}
