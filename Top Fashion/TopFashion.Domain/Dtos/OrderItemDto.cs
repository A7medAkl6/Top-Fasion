namespace Top_Fashion.TopFashion.Domain.Dtos
{
    public class OrderItemDto
    {
        public int ProductItemId { get; set; }
        public string ProductItemName { get; set; }
        public string PictureUrl { get; set; }

        public decimal Price { get; set; }
        public decimal VAT { get; set; }
        public int Quantity { get; set; }
    }
}
