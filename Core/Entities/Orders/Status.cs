namespace Core.Entities.Orders;

public enum Status
{
    Pending,
    PaymentReceived,
    Shipped,
    Delivered,
    Cancelled,
}
