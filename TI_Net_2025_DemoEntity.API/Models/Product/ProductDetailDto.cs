namespace TI_Net_2025_DemoEntity.API.Models.Product
{
    public class ProductDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Price { get; set; }
        public int AlcoholLevel { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
    }
}
