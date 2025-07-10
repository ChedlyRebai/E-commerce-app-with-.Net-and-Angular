using System;
using Core.Entities.Orders;

namespace Core.DTO;

public record OrderDTO
{
    public int deliveryMethodId { get; set; }
    public string basketId { get; set; }

    public ShipAddressDTO shippingAddress { get; set; }
}

public record ShipAddressDTO
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string street { get; set; }
    public string city { get; set; }
    public string ZipCode { get; set; }
    public string state { get; set; }
  
}
