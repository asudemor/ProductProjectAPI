using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductProjectAPI.Core;

namespace ProductProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ProductController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductEntity>>> Get()
        {
            return Ok(await _dataContext.productEntities.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductEntity>> Get(int id)
        {
            var product = await _dataContext.productEntities.FindAsync(id);
            if (product == null)
                return BadRequest("Ürün id bulunamadı.");
            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult<List<ProductEntity>>> AddProduct(ProductEntity product)
        {
            _dataContext.productEntities.Add(product);
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.productEntities.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<ProductEntity>>> UpdateProduct(ProductEntity upPro)
        {
            var product = await _dataContext.productEntities.FindAsync(upPro.Id);
            if (product == null)
                return BadRequest("Ürün id ye ait bilgi bulunamadı.");
            product.Name = upPro.Name;
            product.Price = upPro.Price;
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.productEntities.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ProductEntity>>> DeleteProduct(int id)
        {
            var product = await _dataContext.productEntities.FindAsync(id);
            if (product == null)
                return NotFound("Silinecek ürün bulunamadı.");
            _dataContext.productEntities.Remove(product);
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.productEntities.ToListAsync());
        }
    }
}