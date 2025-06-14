using System;
using Infrastructure.Repositories;

namespace Core.Interfaces;

public interface IUnitOfWork
{
    //The IUnitOfWork interface is part of the Unit of Work pattern, 
    // which is commonly used in software development to manage 
    // database transactions and coordinate changes across multiple repositories.
    //  This interface defines a contract for working with multiple repositories in a
    //  consistent and transactional manner.
    public ICategoryReppository CategoryReppository { get; }
    public IProductRepository ProductRepository { get; }
    public IPhotoRepository PhotoRepository { get; }

    public ICustomerBasketRepository CustomerBasket { get; }
    public IAuth Auth { get; }
}
