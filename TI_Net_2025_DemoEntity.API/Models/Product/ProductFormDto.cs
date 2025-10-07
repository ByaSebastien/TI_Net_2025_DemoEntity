using System.ComponentModel.DataAnnotations;

namespace TI_Net_2025_DemoEntity.API.Models.Product
{
    public class ProductFormDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(0 , int.MaxValue)]
        public int Price { get; set; }

        [Required]
        [Range(0 , 100)]
        public int AlcoholLevel { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }
    }
}
