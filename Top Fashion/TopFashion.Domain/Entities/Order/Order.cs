﻿namespace Top_Fashion.TopFashion.Domain.Entities.Order
{
    public class Order : BaseEntity<int>
    {
        public Order()
        {

        }
        public Order(string buyerEmail, ShipAddress shipToAddress, DeliveryMethod deliveryMethod, IReadOnlyList<OrderItem> orderItems, decimal subtotal, string paymentIntentId)
        {
            BuyerEmail = buyerEmail;
            ShipToAddress = shipToAddress;
            DeliveryMethod = deliveryMethod;
            OrderItems = orderItems;
            Subtotal = subtotal;
            PaymentIntentId = paymentIntentId;

        }

        public string BuyerEmail { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public ShipAddress ShipToAddress { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public IReadOnlyList<OrderItem> OrderItems { get; set; }
        public decimal Subtotal { get; set; }
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;

        public string PaymentIntentId { get; set; }


        public decimal GetTotal()
        {
            return Subtotal + DeliveryMethod.Price;
        }

    }
}
