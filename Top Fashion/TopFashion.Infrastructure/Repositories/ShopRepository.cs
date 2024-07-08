using Top_Fashion.TopFashion.Domain.Entities;
using Top_Fashion.TopFashion.Domain.Interfaces;
using Top_Fashion.TopFashion.Infrastructure.Data;

namespace Top_Fashion.TopFashion.Infrastructure.Repositories
{
    public class ShopRepository : GenericRepository<Shop>, IShopRepository
    {
        private readonly ApplicationDbContext _context;
        public ShopRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
    
}
