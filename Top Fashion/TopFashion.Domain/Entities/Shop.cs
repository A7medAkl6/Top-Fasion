namespace Top_Fashion.TopFashion.Domain.Entities
{
    public class Shop : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();
    }
}
