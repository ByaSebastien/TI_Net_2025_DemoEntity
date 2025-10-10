using Microsoft.EntityFrameworkCore;
using TI_Net_2025_DemoEntity.BLL.Services.Interfaces;
using TI_Net_2025_DemoEntity.DAL.Repositories;
using TI_Net_2025_DemoEntity.DAL.Repositories.Interfaces;
using TI_Net_2025_DemoEntity.DL.Entities;

namespace TI_Net_2025_DemoEntity.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetProducts(int page = 0)
        {
            return _productRepository.GetProducts(page);
        }

        public Product GetProduct(int id)
        {
            Product? product = _productRepository.FindOne(id);

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
            Product? existing = _productRepository.FindOne(id);

            if (existing == null)
            {
                throw new Exception($"Product with id : {id} doesn't exist.");
            }

            existing.Name = product.Name;
            existing.Price = product.Price;
            existing.AlcoholLevel = product.AlcoholLevel;
            existing.Description = product.Description;

            _productRepository.Update(existing);
        }

        public void Delete(int id)
        {
            Product? existing = _productRepository.FindOne(id);

            if (existing == null)
            {
                throw new Exception($"Product with id : {id} doesn't exist.");
            }

            _productRepository.Delete(existing);
        }
    }
}
