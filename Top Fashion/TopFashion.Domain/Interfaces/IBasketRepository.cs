using Top_Fashion.TopFashion.Domain.Entities;

namespace Top_Fashion.TopFashion.Domain.Interfaces
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetBasketAsync(string basketId);
        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket customerBasket);
        Task<bool> DeleteBasketAsync(string basketId);
    }
}
