using System;

namespace Core.Entities;

public class CustomerBasket
{
    public string Id { get; set; } //key
    public List<BasketItem> Items { get; set; } = new List<BasketItem>(); //value

    public CustomerBasket()
    {
    }
    public CustomerBasket(string id)
    {
        Id = id;
    }
    }
