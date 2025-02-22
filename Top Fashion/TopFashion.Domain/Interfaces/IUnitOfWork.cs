﻿namespace Top_Fashion.TopFashion.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IBasketRepository BasketRepository { get; }
        public IShopRepository ShopRepository { get; }
    }
}
