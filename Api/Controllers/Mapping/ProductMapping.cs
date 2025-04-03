using System;
using Core.DTO;
using AutoMapper;
using Core.Entities.Product;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Api.Controllers.Mapping;

public class ProductMapping:Profile
{
    public ProductMapping(){
        CreateMap<Product,ProductDTO>
        ().ForMember(
            x=>x.CategoryName, 
            op=>op.MapFrom(src=>src.Category.Name))
        .ReverseMap();
    }
}
