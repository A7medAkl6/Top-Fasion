using AutoMapper;
using Top_Fashion.TopFashion.Domain.Dtos;
using Top_Fashion.TopFashion.Domain.Entities.Order;

namespace Top_Fashion.TopFashion.Main.Helper
{

    public class OrderItemUrlResolver : IValueResolver<OrderItem, OrderItemDto, string>
    {
        private readonly IConfiguration _config;

        public OrderItemUrlResolver(IConfiguration config)
        {
            _config = config;
        }
        public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ProductItemOrderd.PictureUrl))
            {
                return _config["ApiURl"] + source.ProductItemOrderd.PictureUrl;
            }
            return null;
        }
    }
}
