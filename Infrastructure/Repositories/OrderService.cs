using System;
using System.Linq;
using AutoMapper;
using Core.DTO;
using Core.Entities.Orders;
using Core.Interfaces;
using Core.Services;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    public OrderService(AppDbContext context, IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._context = context;
        this._unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<Orders> CreateOrdersAsync(OrderDTO orderDTO, string buyerEmail)
    {
        var basket = await _unitOfWork.CustomerBasket.GetBasketAsync(orderDTO.basketId);
        if (basket == null)
        {
            throw new Exception("Basket not found");
        }

        List<OrderItem> orderItems = new List<OrderItem>();
        foreach (var item in basket.Items)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(item.Id);
            if (product == null)
            {
                throw new Exception($"Product with ID {item.Id} not found");
            }

            var imageUrl = product.Photos != null && product.Photos.Any()
                ? product.Photos[0].Url
                : "default";

            var orderItem = new OrderItem(
                productItemId: product.Id,
                productName: product.Name,
                price: product.NewPrice,
                quantity: item.Quantity,
                mainImage: imageUrl
            );

            orderItems.Add(orderItem);
        }


        var deliveryMethod = await _context.DeliveryMethods.FirstOrDefaultAsync(m => m.Id == orderDTO.deliveryMethodId);
        if (deliveryMethod == null)
        {
            throw new Exception("Delivery method not found");
        }
        var subTotal = orderItems.Sum(item => item.Price * item.Quantity);
        var ship = _mapper.Map<ShippingAddress>(orderDTO.shippingAddress);
        var order = new Orders(buyerEmail, subTotal, ship, deliveryMethod, orderItems);

        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
        return order;
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
