using AutoMapper;
using Top_Fashion.TopFashion.Domain.Dtos;
using Top_Fashion.TopFashion.Domain.Entities;
using Top_Fashion.TopFashion.Main.Helper;

namespace Top_Fashion.TopFashion.Main.Mapping_Profiles
{
    public class MappingProduct : Profile
    {
        public MappingProduct()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.Category.Name))
                .ForMember(d => d.ProductPicture, o => o.MapFrom<ProductUrlResolver>())
                .ReverseMap();
            CreateMap<CreateProductDto, Product>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();

        }
    }
}
