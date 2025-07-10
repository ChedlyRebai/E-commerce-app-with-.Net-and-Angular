using System;
using Core.DTO;
using Core.Entities.Orders;
using Core.Interfaces;
using Core.Services;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly AppDbContext _context;
    public OrderService(AppDbContext context, IUnitOfWork unitOfWork)
    {
        this._context = context;
        this._unitOfWork = unitOfWork;
    }
    public Task<Orders> CreateOrdersAsync(OrderDTO orderDTO, string buyerEmail)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Orders>> GetAllOrdersAsync(string buyerEmail)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Orders> GetOrderByIdAsync(int id, string buyerEmail)
    {
        throw new NotImplementedException();
    }
}
