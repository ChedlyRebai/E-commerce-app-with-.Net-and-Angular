using System;

namespace Core.Entities.Orders;

public class OrderItem
{

    public OrderItem(int productItemId, string productName, string mainImage, decimal price, int quantity)
    {
        ProductItemId = productItemId;
        ProductName = productName;
        MainImage = mainImage;
        Price = price;
        Quantity = quantity;
    }
    
    public int ProductItemId { get; set; }
    public string ProductName { get; set; }
    public string MainImage { get; set; }

    public decimal Price { get; set; }
    public int Quantity { get; set; }



}
