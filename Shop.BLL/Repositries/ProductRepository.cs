using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.BLL.Interface;
using Shop.DAL.Context;
using Shop.DAL.Entities;

namespace Shop.BLL.Repositries
{
    public class ProductRepository : GenericRepositry<Product>, IProductRepo
    {
        private readonly AppilcationDbContext _context;

        public ProductRepository(AppilcationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetTodowithCat()
        {
            return _context.Products.Include(p => p.Category).ToList();
        }
    }

}
