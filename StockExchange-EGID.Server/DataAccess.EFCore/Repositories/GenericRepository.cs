﻿using Microsoft.EntityFrameworkCore;
using StockExchange_EGID.Server.DataAccess.EFCore;
using StockExchange_EGID.Server.Domain.Contracts;
using System.Linq.Expressions;

namespace StockExchange_EGID.Server.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class 
    {
        protected ApplicationContext _applicationContext { get; set; }
        public GenericRepository(ApplicationContext applicationContext) 
        {
            _applicationContext = applicationContext;
        }
        public IQueryable<T> QueryableNoTracking => _applicationContext.Set<T>().AsNoTracking<T>();
        public T? GetById(Guid id) // TODO: change this id type to string
        {
            return _applicationContext.Set<T>()
                                      .Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _applicationContext.Set<T>().ToList();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _applicationContext.Set<T>().Where(expression);
        }

        public void Create(T entity)
        {
            _applicationContext.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            _applicationContext.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            _applicationContext.Set<T>().Remove(entity);
        }
    }
}
