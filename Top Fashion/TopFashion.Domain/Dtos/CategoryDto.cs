using System.ComponentModel.DataAnnotations;

namespace Top_Fashion.TopFashion.Domain.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShopName { get; set; }
    }
    public class ReturnCategoryDto
    {
        public int TotalCategory { get; set; }
        public List<CategoryDto> CategoryDtos { get; set; }
    }
    public class ListingCategoryDto : CategoryDto
    {
        public int ShopId { get; set; }
    }

    //public class UpdateCategoryDto : CategoryDto
    //{
    //    public int Id { get; set; }
    //    public int ShopId { get; set; }
    //}

}
