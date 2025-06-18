using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.BLL.Repositries;
using Shop.DAL.Entities;

namespace Shop.BLL.Interface
{
    public interface IProductRepo : IGenericRepository<Product>
    {
        IEnumerable<Product> GetTodowithCat();
    }
}
