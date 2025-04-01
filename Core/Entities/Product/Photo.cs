using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Product;

public class Photo:BaseEntity<int>
{
    public string Url { get; set; } = string.Empty;
    public int ProductId { get; set; }
    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; } = new Product();
    
}
