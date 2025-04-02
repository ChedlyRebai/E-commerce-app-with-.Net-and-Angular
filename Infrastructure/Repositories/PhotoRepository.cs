using System;

using Core.Entities;
using Core.Entities.Product;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class PhotoRepository : GenericRepository<Photo>, IPhotoRepository
{
    public PhotoRepository(AppDbContext context) : base(context)
    {
    }
}
