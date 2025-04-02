using System;
using Infrastructure.Repositories;

namespace Core.Interfaces;

public interface IUnitOfWork
{
    public ICategoryReppository CategoryReppository { get; }
    public IProductRepository ProductRepository { get; }
    public IPhotoRepository PhotoRepository { get; }
}
