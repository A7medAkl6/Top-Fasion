using AutoMapper;
using Top_Fashion.TopFashion.Domain.Dtos;
using Top_Fashion.TopFashion.Domain.Entities;
using Top_Fashion.TopFashion.Main.Helper;

namespace Top_Fashion.TopFashion.Main.Mapping_Profiles
{
    public class MappingCategory : Profile
    {
        public MappingCategory()
        {
            CreateMap<Category, CategoryDto>()
               .ForMember(d => d.ShopName, o => o.MapFrom(s => s.Shop.Name))
               .ReverseMap();
            CreateMap<ListingCategoryDto, Category>().ReverseMap();
            // CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        }
    }
}
