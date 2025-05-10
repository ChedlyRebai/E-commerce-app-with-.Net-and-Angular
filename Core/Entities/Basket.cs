using System;

namespace Core.Entities;

public class Basket
{
    public int Id { get; set; } //key
    public List<BasketItem> Items { get; set; } = new List<BasketItem>(); //value
}
