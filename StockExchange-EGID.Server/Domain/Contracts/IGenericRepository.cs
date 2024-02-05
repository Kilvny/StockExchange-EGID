﻿using System.Linq.Expressions;

namespace StockExchange_EGID.Server.Domain.Contracts
{
    public interface IGenericRepository<T> where T: class
    {
        T? GetById(Guid id);
        IEnumerable<T> GetAll();
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> QueryableNoTracking { get; }

    }
}
