using System;
using Core.Entities;

namespace Core.Interfaces;

public interface ICustomerBasketRepository
{
    Task<CustomerBasket> GetBasketAsync(string basketId);
    Task<CustomerBasket> UpdateCustomerBasketAsync(CustomerBasket basket);
    Task<bool> DeleteBasketAsync(string basketId);
}
