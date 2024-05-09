using AutoMapper;
using Top_Fashion.TopFashion.Domain.Dtos;
using Top_Fashion.TopFashion.Domain.Entities;

namespace Top_Fashion.TopFashion.Main.Mapping_Profiles
{
    public class MappingBasket : Profile
    {
        public MappingBasket()
        {
            CreateMap<CustomerBasket, CustomerBasketDto>().ReverseMap();
            CreateMap<BasketItem, BasketItemDto>().ReverseMap();
        }
    }
}
