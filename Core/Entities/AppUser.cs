using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Core.Entities;

public class AppUser : IdentityUser
{
    public string DisplayName { get; set; }
    
    public Address Address { get; set; }
    public int AddressId { get; set; }
}
