namespace Core.DTO;

public record class ProductDTO(
    string Name , string Description,decimal Price,int Stock,int CategoryId
);

public record UpdateProdcutDTO(
    string Name, string Description, decimal Price, int Stock, int CategoryId,int id
);