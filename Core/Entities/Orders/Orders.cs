using System;

namespace Core.Entities.Orders;

public class Orders : BaseEntity<int>


{
    public Orders(string buyerEmail, decimal subTotal, ShippingAddress shippingAddress, DeliveryMethod deliveryMethod, IReadOnlyList<OrderItem> orderItems)
    {
        BuyerEmail = buyerEmail;
        OrderDate = DateTime.Now;
        this.OrderItems = orderItems;

        SubTotal = subTotal;
        this.shippingAddress = shippingAddress;
        this.deliveryMethod = deliveryMethod;
        OrderDate = DateTime.UtcNow;
    }

    public Orders()
    {

    }
    public string BuyerEmail { get; set; }
    public decimal SubTotal { get; set; }

    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public ShippingAddress shippingAddress { get; set; }

    public DeliveryMethod deliveryMethod { get; set; }

    public IReadOnlyList<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public Status status { get; set; } = Status.Pending;

    public decimal GetTotal()
    {
        return SubTotal + deliveryMethod.Price;
    }
}
