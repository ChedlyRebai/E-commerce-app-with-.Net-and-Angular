using System;
using System.Text.Json;
using Core.Entities;
using Core.Interfaces;
using StackExchange.Redis;


namespace Infrastructure.Repositories;

public class CustomerBasketRepository : ICustomerBasketRepository
{
    private readonly IDatabase _database;
    public CustomerBasketRepository(IConnectionMultiplexer redis)
    {
        _database = redis.GetDatabase();
    }
    public async Task<CustomerBasket> GetBasketAsync(string basketId)
    {
        var result = await _database.StringGetAsync(basketId);
        if (result.HasValue)
        {
            return JsonSerializer.Deserialize<CustomerBasket>(result);
        }
        return null;
    }

    public Task<bool> DeleteBasketAsync(string basketId)
    {
        return _database.KeyDeleteAsync(basketId);
    }

    

    public async Task<CustomerBasket> UpdateCustomerBasketAsync(CustomerBasket basket)
    {
        var _basket =await _database.StringSetAsync(basket.Id ,JsonSerializer.Serialize(basket),TimeSpan.FromDays(3));
        if (_basket)
        {
            return await GetBasketAsync(basket.Id);
        }

        return null;
    }
}
