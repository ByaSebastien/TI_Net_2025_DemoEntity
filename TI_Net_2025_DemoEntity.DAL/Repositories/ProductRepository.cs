using Microsoft.EntityFrameworkCore;
using TI_Net_2025_DemoEntity.DAL.Contexts;
using TI_Net_2025_DemoEntity.DAL.Repositories.Interfaces;
using TI_Net_2025_DemoEntity.DL.Entities;
using TI_Net_2025_DemoEntity.ToolBoxEF.Repositories;

namespace TI_Net_2025_DemoEntity.DAL.Repositories
{
    public class ProductRepository: BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(DemoEntityContext context) : base(context) { }

        public IEnumerable<Product> GetProducts(int page = 0, Func<Product, bool>? predicate = null)
        {

            IEnumerable<Product> query = _entities;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query
                .OrderBy(p => p.Name)
                .Skip(page * 10)
                .Take(10);
        }
    }
}
