using Top_Fashion.TopFashion.Domain.Entities;
using Top_Fashion.TopFashion.Domain.Interfaces;
using Top_Fashion.TopFashion.Infrastructure.Data;

namespace Top_Fashion.TopFashion.Infrastructure.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
