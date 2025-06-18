using Shop.BLL.Interface;
using Shop.DAL.Context;
using Shop.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Shop.BLL.Repositries
{
    public class GenericRepositry<T> : IGenericRepository<T> where T : class
    {
        private readonly AppilcationDbContext _context;

        public GenericRepositry(AppilcationDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T getById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}
