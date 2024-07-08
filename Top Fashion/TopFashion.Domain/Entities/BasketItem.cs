﻿namespace Top_Fashion.TopFashion.Domain.Entities
{
    public class BasketItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductPicture { get; set; }
        public decimal Price { get; set; }
        public decimal Vat { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }

    }
}
