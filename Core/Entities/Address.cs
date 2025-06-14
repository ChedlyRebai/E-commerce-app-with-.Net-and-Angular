using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class Address : BaseEntity<int>
{

    public string firstName { get; set; }
    public string lastName { get; set; }
    public string street { get; set; }
    public string city { get; set; }
    public string ZipCode { get; set; }
    public string state { get; set; }
    public string country { get; set; }

    public string AppUserId { get; set; }
    [ForeignKey(nameof(AppUserId))]

    public virtual AppUser AppUser { get; set; }



}
