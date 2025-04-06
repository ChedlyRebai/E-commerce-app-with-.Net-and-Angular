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
        //.ForMember(dest => dest.Photos, opt => opt.MapFrom(src => src.Photos))
        .ReverseMap();
        CreateMap<Photo,PhotoDTO>()
        .ForMember(x=> x.ImageName, opt=> opt.MapFrom(src=>src.Url) )
        .ReverseMap();

        CreateMap<AddProductDTo,Product>()
        .ForMember(x=>x.Photos,opt=>opt.Ignore()).ReverseMap();
    }
}
