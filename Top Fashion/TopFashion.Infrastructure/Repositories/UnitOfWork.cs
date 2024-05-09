using AutoMapper;
using Microsoft.Extensions.FileProviders;
using StackExchange.Redis;
using Top_Fashion.TopFashion.Domain.Interfaces;
using Top_Fashion.TopFashion.Infrastructure.Data;

namespace Top_Fashion.TopFashion.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileProvider _fileProvider;
        private readonly IConnectionMultiplexer _redis;

        public ICategoryRepository CategoryRepository { get; }

        public IProductRepository ProductRepository { get; }

        public IBasketRepository BasketRepository { get; }

        public UnitOfWork(ApplicationDbContext context, IMapper mapper, IFileProvider fileProvider,IConnectionMultiplexer redis)
        {
            _context = context;
            _mapper = mapper;
            _fileProvider = fileProvider;
            _redis = redis;
            CategoryRepository = new CategoryRepository(_context);
            ProductRepository = new ProductRepository(_context, _fileProvider, _mapper);
             BasketRepository = new BasketRepository(_redis);
        }
    }
}
