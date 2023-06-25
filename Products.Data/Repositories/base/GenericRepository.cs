using Microsoft.EntityFrameworkCore;
using Products.Data.Context;
using Products.Domain.Interfaces.Repository.@base;
using System.Linq.Expressions;

namespace Products.Data.Repositories.@base
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DataContext _context { get; set; }

        internal DbSet<T> dbSet;
        public GenericRepository(DataContext context)
        {
            _context = context;
            this.dbSet = _context.Set<T>();
        }
        public async void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }
        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            _context.SaveChanges();
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public T GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public IQueryable<T> Query(string query)
        {
            return _context.Set<T>().FromSqlRaw(query);
        }
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            _context.SaveChanges();
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}