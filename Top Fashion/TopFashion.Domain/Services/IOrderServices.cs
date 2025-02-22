﻿using Top_Fashion.TopFashion.Domain.Entities.Order;

namespace Top_Fashion.TopFashion.Domain.Services
{
    public interface IOrderServices
    {
        Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, ShipAddress shipAddress);
        Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail);
        Task<Order> GetOrderByIdAsync(int id, string buyerEmail);
        Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync();
    }
}
