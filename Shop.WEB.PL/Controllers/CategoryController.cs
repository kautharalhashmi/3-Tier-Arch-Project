using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.BLL.Interface;
using Shop.DAL.Entities;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Protect the API using Identity
    public class CategoriesController : ControllerBase
    {
        private readonly IGenericRepository<Category> _categoryRepo;

        public CategoriesController(IGenericRepository<Category> categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        // GET: api/categories
        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _categoryRepo.GetAll();
            return Ok(categories);
        }

        // GET: api/categories/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = _categoryRepo.getById(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

        // POST: api/categories
        [HttpPost]
        public IActionResult Create([FromBody] Category category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _categoryRepo.Add(category);
            return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
        }

        // PUT: api/categories/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Category category)
        {
            if (id != category.Id)
                return BadRequest("Category ID mismatch.");

            var existing = _categoryRepo.getById(id);
            if (existing == null)
                return NotFound();

            _categoryRepo.Update(category);
            return NoContent();
        }

        // DELETE: api/categories/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _categoryRepo.getById(id);
            if (category == null)
                return NotFound();

            _categoryRepo.Delete(category);
            return NoContent();
        }
    }
}
