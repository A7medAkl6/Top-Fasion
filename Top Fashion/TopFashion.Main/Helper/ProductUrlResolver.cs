using AutoMapper;
using Top_Fashion.TopFashion.Domain.Dtos;
using Top_Fashion.TopFashion.Domain.Entities;

namespace Top_Fashion.TopFashion.Main.Helper
{
    public class ProductUrlResolver : IValueResolver<Product, ProductDto, string>
    {
        private readonly IConfiguration _config;

        public ProductUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ProductPicture))
            {
                return _config["ApiURL"] + source.ProductPicture;
            }
            return null;
        }
    }

}
