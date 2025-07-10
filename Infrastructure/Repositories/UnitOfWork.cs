using System;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Services;
using Infrastructure.Data;
using Infrastructure.Repositories.Service;
using Microsoft.AspNetCore.Identity;
using StackExchange.Redis;
namespace Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly IImageMangeService _imageMangeService;
    private readonly IConnectionMultiplexer _redis;
    public ICategoryReppository CategoryReppository { get; }
    public IProductRepository ProductRepository { get; }
    public IPhotoRepository PhotoRepository { get; }
    public ICustomerBasketRepository CustomerBasket { get; }

    private readonly UserManager<AppUser> _userManager;

    private readonly IEmailService emailService;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IGenerateToken token;
    public IAuth Auth { get; }

    public UnitOfWork(AppDbContext context, IMapper mapper, IImageMangeService imageMangeService, IConnectionMultiplexer redis, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IEmailService emailService = null, IGenerateToken token = null)
    {

        _mapper = mapper;
        _imageMangeService = imageMangeService;
        _context = context;
        _redis = redis;
        CategoryReppository = new CategoryRepository(_context);
        ProductRepository = new ProductRepository(_context, _mapper, _imageMangeService);
        PhotoRepository = new PhotoRepository(_context);
        CustomerBasket = new CustomerBasketRepository(_redis);
        this._userManager = userManager;
        Auth = new AuthRepository(_userManager, emailService, signInManager,token);
        _signInManager = signInManager;
        this.emailService = emailService;
        this.token = token;
    }
}