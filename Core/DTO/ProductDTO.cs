using Microsoft.AspNetCore.Http;

namespace Core.DTO;

public record ProductDTO(){
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal NewPrice { get; set; }
    public decimal OldPrice { get; set; }
    public int Stock { get; set; }
    public string CategoryName { get; set; }

    public virtual List<PhotoDTO> Photos { get; set; }  
}

public record PhotoDTO
{
    public string ImageName { get; set;}
    public int ProductId { get; set; }
}

public record AddProductDTo{
     public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal NewPrice { get; set; }
    public decimal OldPrice { get; set; }
    public IFormFileCollection Photo {get; set;} 

    
}