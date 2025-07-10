 using System;
using Core.DTO;
using Core.Entities.Orders;

namespace Core.Services;

public interface IOrderService
{
    Task<Orders> CreateOrdersAsync(OrderDTO orderDTO, string buyerEmail);
    Task<IReadOnlyList<Orders>> GetAllOrdersAsync(string buyerEmail);
    Task<Orders> GetOrderByIdAsync(int id, string buyerEmail);

    Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodByIdAsync(int id);
    

}
