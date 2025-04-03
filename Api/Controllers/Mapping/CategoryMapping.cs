using System;
using AutoMapper;
using Core.DTO;
using Core.Entities.Product;

namespace Api.Controllers.Mapping;

public class CategoryMapping:Profile
{
    public CategoryMapping(){
        CreateMap<CategoryDTO,Category>().ReverseMap();
        CreateMap<UpdateCategoryDTO,Category>().ReverseMap();
    }

}
