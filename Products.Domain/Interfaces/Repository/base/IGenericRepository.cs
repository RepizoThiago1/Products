﻿using System.Linq.Expressions;

namespace Products.Domain.Interfaces.Repository.@base
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(Guid id);
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        IQueryable<T> Query(string query);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void SaveChanges();
    }
}
