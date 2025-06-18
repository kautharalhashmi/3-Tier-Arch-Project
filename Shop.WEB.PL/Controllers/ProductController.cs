using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.BLL.Interface;
using Shop.DAL.Entities;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IProductRepo _productCustomRepo;

        public ProductsController(IGenericRepository<Product> productRepo, IProductRepo productCustomRepo)
        {
            _productRepo = productRepo;
            _productCustomRepo = productCustomRepo;
        }

        // GET: api/products
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productCustomRepo.GetTodowithCat();
            return Ok(products);
        }

        // GET: api/products/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _productRepo.getById(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // POST: api/products
        [HttpPost]
        public IActionResult Create([FromBody] Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _productRepo.Add(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        // PUT: api/products/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Product product)
        {
            if (id != product.Id)
                return BadRequest("Product ID mismatch.");

            var existing = _productRepo.getById(id);
            if (existing == null)
                return NotFound();

            _productRepo.Update(product);
            return NoContent();
        }

        // DELETE: api/products/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _productRepo.getById(id);
            if (product == null)
                return NotFound();

            _productRepo.Delete(product);
            return NoContent();
        }
    }
}
