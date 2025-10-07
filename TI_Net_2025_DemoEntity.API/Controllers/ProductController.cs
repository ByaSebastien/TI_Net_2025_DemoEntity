using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TI_Net_2025_DemoEntity.API.Mappers;
using TI_Net_2025_DemoEntity.API.Models.Product;
using TI_Net_2025_DemoEntity.BLL.Services;

namespace TI_Net_2025_DemoEntity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<List<ProductIndexDto>> GetProducts([FromQuery] int page = 0)
        {
            List<ProductIndexDto> products = _productService.GetProducts(page)
                .Select(p => p.ToProductIndexDto())
                .ToList();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDetailDto> GetProduct([FromRoute] int id)
        {
            ProductDetailDto product = _productService.GetProduct(id).ToProductDetailDto();

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Add([FromBody] ProductFormDto form)
        {
            _productService.Add(form.ToProduct());

            return NoContent();
        }

        [HttpPost("many")]
        public IActionResult AddMany([FromBody] List<ProductFormDto> list)
        {
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] ProductFormDto form)
        {
            _productService.Update(id, form.ToProduct());
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _productService.Delete(id);
            return NoContent();
        }
    }
}
