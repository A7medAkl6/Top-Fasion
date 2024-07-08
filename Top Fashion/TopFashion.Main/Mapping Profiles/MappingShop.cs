using AutoMapper;
using Top_Fashion.TopFashion.Domain.Dtos;
using Top_Fashion.TopFashion.Domain.Entities;

namespace Top_Fashion.TopFashion.Main.Mapping_Profiles
{
    public class MappingShop : Profile
    {
        public MappingShop()
        {
            CreateMap<ShopDto, Shop>().ReverseMap();
            CreateMap<ListingShopDto, Shop>().ReverseMap();
            //CreateMap<UpdateShopDto, Shop>().ReverseMap();
        }
    }
}
