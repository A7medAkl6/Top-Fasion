using Stripe;

namespace Top_Fashion.TopFashion.Domain.Entities
{
    public class Product : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ProductPicture { get; set; }
        public decimal Vat { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }

}
