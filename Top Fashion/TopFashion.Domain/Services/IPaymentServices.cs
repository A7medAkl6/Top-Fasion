using Top_Fashion.TopFashion.Domain.Entities;
using Top_Fashion.TopFashion.Domain.Entities.Order;

namespace Top_Fashion.TopFashion.Domain.Services
{
    public interface IPaymentServices
    {
        Task<CustomerBasket> CreateOrUpdatePayment(string basketId);
        Task<Order> UpdateOrderPaymentSucceeded(string paymentIntentId);
        Task<Order> UpdateOrderPaymentFailed(string paymentIntentId);
    }
}
