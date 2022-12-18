using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductProjectAPI.Core;

namespace ProductProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private static List<ProductEntity> products = new List<ProductEntity>
            {
                new ProductEntity{Id=1,Name="Cep Telefonu", Price="10000" },
                new ProductEntity{Id=2,Name="Bilgisayar", Price="15000" },
                new ProductEntity{Id=3,Name="Şarj Aleti", Price="500" }
            };

        [HttpGet]
        public async Task<ActionResult<List<ProductEntity>>> Get()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductEntity>> Get(int id)
        {
            var product = products.Find(x => x.Id == id);
            if (product == null)
                return BadRequest("Ürün id bulunamadı.");
            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult<List<ProductEntity>>> AddProduct(ProductEntity product)
        {
            products.Add(product);
            return Ok(products);
        }
        [HttpPut]
        public async Task<ActionResult<List<ProductEntity>>> UpdateProduct(ProductEntity upPro)
        {
            var product = products.Find(x => x.Id == upPro.Id);
            if (product == null)
                return BadRequest("Ürün id ye ait bilgi bulunamadı.");
            product.Name = upPro.Name;
            product.Price = upPro.Price;
            return Ok(products);
        }
        [HttpDelete]
        public async Task<ActionResult<List<ProductEntity>>> DeleteProduct(int id)
        {
            var product = products.Find(x => x.Id == id);
            if (product == null)
                return NotFound("Ürün bulunamadı.");
            products.Remove(product);
            return Ok(products);
        }
    }
}
