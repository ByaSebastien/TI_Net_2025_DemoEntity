using TI_Net_2025_DemoEntity.API.Models.Product;
using TI_Net_2025_DemoEntity.DL.Entities;

namespace TI_Net_2025_DemoEntity.API.Mappers
{
    public static class ProductMappers
    {
        public static ProductIndexDto ToProductIndexDto(this Product p)
        {
            return new ProductIndexDto()
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                AlcoholLevel = p.AlcoholLevel,
            };
        }

        public static ProductDetailDto ToProductDetailDto(this Product p)
        {
            return new ProductDetailDto()
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                AlcoholLevel = p.AlcoholLevel,
                Description = p.Description,
                Quantity = p.Stock?.CurrentQuantity ?? 0,
            };
        }

        public static Product ToProduct(this ProductFormDto p)
        {
            return new Product()
            {
                Name = p.Name,
                Price = p.Price,
                AlcoholLevel = p.AlcoholLevel,
                Description = p.Description,
            };
        }
    }
}
