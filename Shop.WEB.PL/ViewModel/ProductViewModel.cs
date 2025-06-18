using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.DAL.Entities;

namespace Shop.WEB.PL.ViewModel
{
    public class ProductViewModel
    {
        public Product products { get; set; } = new Product();
        public IEnumerable<SelectListItem> Categories { get; set; }
    }

}
