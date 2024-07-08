using Top_Fashion.TopFashion.Domain.Dtos;
using Top_Fashion.TopFashion.Domain.Entities;
using Top_Fashion.TopFashion.Domain.Sharing;

namespace Top_Fashion.TopFashion.Domain.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<ReturnCategoryDto> GetAllAsync(CategoryParams categoryParams);
    }
}
