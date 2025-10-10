namespace TI_Net_2025_DemoEntity.BLL.Exceptions.Product
{
    public class ProductNotFoundException : NotFoundException
    {

        public ProductNotFoundException() : base("Product not found") { }

        public ProductNotFoundException(string message) : base(message) {}
    }
}
