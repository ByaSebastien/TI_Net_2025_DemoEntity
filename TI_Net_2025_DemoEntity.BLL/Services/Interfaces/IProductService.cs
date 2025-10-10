using TI_Net_2025_DemoEntity.DL.Entities;

namespace TI_Net_2025_DemoEntity.BLL.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts(int page = 0);

        Product GetProduct(int id);

        void Add(Product product);

        void Update(int id, Product product);

        void Delete(int id);
    }
}
