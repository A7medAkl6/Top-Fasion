using System.ComponentModel.DataAnnotations;

namespace Top_Fashion.TopFashion.Domain.Dtos
{
    public class ShopDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class ListingShopDto : ShopDto
    {
        public int Id { get; set; }
    }

    //public class UpdateShopDto : ShopDto
    //{
    //    public int Id { get; set; }
    //}
}
