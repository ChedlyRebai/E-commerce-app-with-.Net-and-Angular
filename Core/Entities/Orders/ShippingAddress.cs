using System;
using System.Data.SqlTypes;

namespace Core.Entities.Orders;

public class ShippingAddress : BaseEntity<int>
{
    public ShippingAddress(string firstname,string lastname, string city ,string Zipcode,string street,string state)
    {
        firstName = firstname;
        lastName = lastname;
        this.city = city;
        this.ZipCode = Zipcode;
        this.street = street;
        this.state = state;
    }
    public ShippingAddress()
    {

    }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string street { get; set; }
    public string city { get; set; }
    public string ZipCode { get; set; }
    public string state { get; set; }
  

}
