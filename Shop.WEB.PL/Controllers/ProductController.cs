using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.BLL.Interface;
using Shop.BLL.Repositries;
using Shop.DAL.Entities;
using Shop.WEB.PL.ViewModel;
using System.Threading.Tasks;

namespace Shop.WEB.PL.Controllers
{
    public class ProductController : Controller
    {
        private readonly IGenericRepository<Product> _product;
        private readonly IGenericRepository<Category> _categories;
        private readonly IProductRepo _ProductRepository;


        public ProductController(IGenericRepository<Product> products, IGenericRepository<Category> categories, IProductRepo productRepo)
        {

            _product = products;
            _categories = categories;
            _ProductRepository = productRepo;
        }

        // List all tasks
        public IActionResult Index()
        {
            var prods = _ProductRepository.GetTodowithCat();
            return View(prods);
        }

        // Show add form
        public IActionResult Add()
        {
            var viewModel = new ProductViewModel
            {
                Categories = _categories.GetAll().Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
            };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Add(ProductViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var prod = new Product
                {
                    Name = viewModel.products.Name,
                    Price = viewModel.products.Price,
                    CategoryId = viewModel.products.CategoryId
                };

                _product.Add(prod);
                return RedirectToAction("Index");
            }

            // If ModelState is invalid, reload categories and return to view
            viewModel.Categories = _categories.GetAll().Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            });

            return View(viewModel);
        }


        // Show edit form
        public IActionResult Edit(int id)
        {
            var task = _product.getById(id);
            if (task == null)
                return NotFound();

            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _product.Update(product);
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }



        public IActionResult Delete(int id)
        {
            var task = _product.getById(id);
            if (task == null)
                return NotFound();

            return View(task);
        }

        [HttpPost, ActionName("Delete")]  // This makes the form post to Delete even though method name is different
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var task = _product.getById(id);
            if (task == null)
                return NotFound();

            _product.Delete(task);  // Or pass ID if that's how your Delete works
            return RedirectToAction(nameof(Index));
        }
    }
    }
