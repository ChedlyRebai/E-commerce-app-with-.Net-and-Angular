using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Product;

public class Product:BaseEntity<int>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public virtual Category Category { get; set; } 
     
    public virtual ICollection<Photo> Photos {get; set;}=new HashSet<Photo>();

}
