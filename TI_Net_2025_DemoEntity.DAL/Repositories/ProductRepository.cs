using Microsoft.EntityFrameworkCore;
using TI_Net_2025_DemoEntity.DAL.Contexts;
using TI_Net_2025_DemoEntity.DL.Entities;

namespace TI_Net_2025_DemoEntity.DAL.Repositories
{
    public class ProductRepository
    {
        private readonly DemoEntityContext _context;
        private readonly DbSet<Product> _products;

        public ProductRepository(DemoEntityContext context)
        {
            _context = context;
            _products = context.Products;
        }

        public IEnumerable<Product> GetProducts(int page = 0, Func<Product, bool>? predicate = null)
        {

            IEnumerable<Product> query = _products;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query
                .OrderBy(p => p.Name)
                .Skip(page * 10)
                .Take(10);
        }

        public Product? GetProduct(int id)
        {
            return _products
                .Include(p => p.Stock)
                .SingleOrDefault(p => p.Id == id);

            //return _products.Find(id);
        }

        public void Add(Product product)
        {
            _products.Add(product);
            _context.SaveChanges();
        }

        public void Add(List<Product> products)
        {
            _products.AddRange(products);
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            _products.Update(product);
            _context.SaveChanges();
        }

        public void Delete(Product product)
        {
            _products.Remove(product);
            _context.SaveChanges();
        }
    }
}
