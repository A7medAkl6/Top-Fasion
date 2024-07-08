using System.ComponentModel.DataAnnotations;

namespace Top_Fashion.TopFashion.Domain.Dtos
{
    public class BasketItemDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductPicture { get; set; }
        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Price Must Greater Than Zero")]
        public decimal Price { get; set; }

        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Price Must Greater Than Zero")]
        public decimal Vat { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Quantity Must Greater Than Zero")]
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Category { get; set; }
    }
}
