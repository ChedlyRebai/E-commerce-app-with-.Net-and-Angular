using System;

namespace Core.Entities.Orders;

public class DeliveryMethod : BaseEntity<int>
{
    public DeliveryMethod(string name, string description, decimal price, DateTime deliveryTime)
    {
        Name = name;
        Description = description;
        Price = price;
        DeliveryTime = deliveryTime;
    }
    
    public DeliveryMethod()
    {

    }
    public string Name { get; set; }
    public string Description { get; set; }

    public decimal Price { get; set; }

    public DateTime DeliveryTime { get; set; }
  
}
