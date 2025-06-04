using System;

namespace Core.Entities;

public class BasketItem
{
    public int Id { get; set;}
    public String Name { get; set; }
    public String Image { get; set; }
    public String Quantity { get; set; }
    public decimal Price { get; set; }
    public String Category { get; set; }
}
