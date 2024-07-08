namespace Top_Fashion.TopFashion.Domain.Entities.Order
{
    public class OrderItem : BaseEntity<int>
    {
        public OrderItem()
        {

        }
        public OrderItem(ProductItemOrderd productItemOrderd, decimal price, int quantity,decimal vat)
        {
            ProductItemOrderd = productItemOrderd;
            Price = price;
            Quantity = quantity;
            Vat = vat;
        }

        public ProductItemOrderd ProductItemOrderd { get; set; }
        public decimal Price { get; set; }
        public decimal Vat { get; set; }
        public int Quantity { get; set; }
    }
}
