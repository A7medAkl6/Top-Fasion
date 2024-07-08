namespace Top_Fashion.TopFashion.Domain.Entities
{
    public class Category : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ShopId { get; set; }
        public virtual Shop Shop { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
