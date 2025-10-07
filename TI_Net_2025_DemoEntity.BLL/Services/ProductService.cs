using TI_Net_2025_DemoEntity.DAL.Repositories;
using TI_Net_2025_DemoEntity.DL.Entities;

namespace TI_Net_2025_DemoEntity.BLL.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetProducts(int page = 0)
        {
            return _productRepository.GetProducts(page);
        }

        public Product GetProduct(int id)
        {
            Product? product = _productRepository.GetProduct(id);

            if(product == null)
            {
                throw new Exception($"Product with id : {id} doesn't exist");
            }

            return product;
        }

        public void Add(Product product)
        {
            _productRepository.Add(product);
        }

        public void Update(int id, Product product)
        {
            _productRepository.Update(id, product);
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }
    }
}
