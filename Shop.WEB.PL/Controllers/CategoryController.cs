using Microsoft.AspNetCore.Mvc;
using Shop.DAL.Entities;

using System.Threading.Tasks;
using Shop.BLL.Interface;
using Shop.BLL.Repositries;

namespace Shop.WEB.PL.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IGenericRepository<Category> _category;

        public CategoryController(IGenericRepository<Category> category)
        {
            _category = category;
        }

        public IActionResult Index()
        {
            var cat = _category.GetAll();
            return View(cat);
        }

        [HttpPost]
        public IActionResult Add(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                var newCategory = new Category { Name = name };
                _category.Add(newCategory);

            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var cat = _category.getById(id);
            if (cat == null) return NotFound();
            return View(cat);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _category.Update(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var cat = _category.getById(id);
            if (cat != null)
            {
                _category.Delete(cat);
            }
            return RedirectToAction(nameof(Index));
        }
    }
    }
