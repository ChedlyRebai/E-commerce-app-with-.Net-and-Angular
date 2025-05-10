using System;

namespace Core.Entities;

public class CustomerBasket
{
    public int Id { get; set; } //key
    public List<BasketItem> Items { get; set; } = new List<BasketItem>(); //value

    public CustomerBasket()
    {
    }
    public CustomerBasket(int id)
    {
        Id = id;
    }
    }
