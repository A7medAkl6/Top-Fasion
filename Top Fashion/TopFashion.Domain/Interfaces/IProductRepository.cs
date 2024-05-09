using Top_Fashion.TopFashion.Domain.Dtos;
using Top_Fashion.TopFashion.Domain.Entities;
using Top_Fashion.TopFashion.Domain.Sharing;

namespace Top_Fashion.TopFashion.Domain.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<ReturnProductDto> GetAllAsync(ProductParams productParams);
        Task<bool> AddAsync(CreateProductDto dto);
        Task<bool> UpdateAsync(int id, UpdateProductDto dto);
        Task<bool> DeleteAsyncWithPicture(int id);
    }
}
