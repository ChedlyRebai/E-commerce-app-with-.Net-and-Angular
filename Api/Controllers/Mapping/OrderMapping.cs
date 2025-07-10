using System;
using AutoMapper;
using Core.DTO;
using Core.Entities.Orders;

namespace Api.Controllers.Mapping;

public class OrderMapping:Profile
{
    public OrderMapping()
    {
        //ReveseMap() allows the mapping to be bidirectional
        //if i send OrderDTO to Orders it will map it to Orders and if i send Orders to OrderDTO it will map it to OrderDTO
        CreateMap<ShippingAddress, ShipAddressDTO>().ReverseMap();
    }
}
