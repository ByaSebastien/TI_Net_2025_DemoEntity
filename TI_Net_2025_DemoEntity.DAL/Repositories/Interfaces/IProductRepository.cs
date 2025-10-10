using TI_Net_2025_DemoEntity.DL.Entities;
using TI_Net_2025_DemoEntity.ToolBoxEF.Repositories;

namespace TI_Net_2025_DemoEntity.DAL.Repositories.Interfaces
{
    public interface IProductRepository: IBaseRepository<Product>
    {
        IEnumerable<Product> GetProducts(int page = 0, Func<Product, bool>? predicate = null);
    }
}
