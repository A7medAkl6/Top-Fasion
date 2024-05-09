using AutoMapper;
using Top_Fashion.TopFashion.Domain.Dtos;
using Top_Fashion.TopFashion.Domain.Entities;

namespace Top_Fashion.TopFashion.Main.Mapping_Profiles
{
    public class MappingCategory : Profile
    {
        public MappingCategory()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<ListingCategoryDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();
        }
    }
}
