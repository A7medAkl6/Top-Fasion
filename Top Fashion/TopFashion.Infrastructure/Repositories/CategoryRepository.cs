using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Top_Fashion.TopFashion.Domain.Dtos;
using Top_Fashion.TopFashion.Domain.Entities;
using Top_Fashion.TopFashion.Domain.Interfaces;
using Top_Fashion.TopFashion.Domain.Sharing;
using Top_Fashion.TopFashion.Infrastructure.Data;

namespace Top_Fashion.TopFashion.Infrastructure.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CategoryRepository(ApplicationDbContext context, IMapper mapper) : base(context)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ReturnCategoryDto> GetAllAsync(CategoryParams categoryParams)
        {
            var result_ = new ReturnCategoryDto();
            var query = await _context.Categories
                .Include(x => x.Shop)
                .AsNoTracking()
                .ToListAsync();

            // Search By Name
            if (!string.IsNullOrEmpty(categoryParams.Search))
                query = query.Where(x => x.Name.ToLower().Contains(categoryParams.Search)).ToList();

            // Filtering By CategoryId
            if (categoryParams.ShopId.HasValue)
            {
                query = query.Where(x => x.ShopId == categoryParams.ShopId.Value).ToList();
            }
            // Sorting
            if (!string.IsNullOrEmpty(categoryParams.Sort))
            {
                query = categoryParams.Sort switch
                {
                    //"PriceAsc" => query.OrderBy(x => x.Price).ToList(),
                    "ID" => query.OrderByDescending(x => x.Id).ToList(),
                    _ => query.OrderBy(x => x.Name).ToList(),
                };
            }
            result_.TotalCategory = query.Count;
            //Paging
            query = query.Skip((categoryParams.PageSize) * (categoryParams.PageNumber - 1)).Take(categoryParams.PageSize).ToList();


            result_.CategoryDtos = _mapper.Map<List<CategoryDto>>(query);
            return result_;
        }

    }
}
