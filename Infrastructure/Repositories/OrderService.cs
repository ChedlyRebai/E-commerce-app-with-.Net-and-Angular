using System;
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
    public OrderService(AppDbContext context, IUnitOfWork unitOfWork)
    {
        this._context = context;
        this._unitOfWork = unitOfWork;
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
            var productItem = await _unitOfWork.ProductRepository.GetByIdAsync(item.Id);
            if (productItem == null)
            {
                var Product = await _unitOfWork.ProductRepository.GetByIdAsync(item.Id);
                var orderItem = new OrderItem(
                    productItemId: Product.Id,
                    productName: Product.Name,
                    price: Product.NewPrice,
                    quantity: item.Quantity,
                    mainImage: Product.Photos[0].Url
                );
                orderItems.Add(orderItem);
            }


        }

        var deliveryMethod = await _context.DeliveryMethods.FirstOrDefaultAsync(m => m.Id == orderDTO.deliveryMethodId);
        var subTotal = orderItems.Sum(item => item.Price * item.Quantity);
        var shipAddre
        var order = new Orders(buyerEmail, subTotal, deliveryMethod, orderItems);
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
