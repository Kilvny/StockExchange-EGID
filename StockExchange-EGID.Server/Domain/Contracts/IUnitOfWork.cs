using Microsoft.EntityFrameworkCore.Storage;
using StockExchange_EGID.Server.Domain.Entities;

namespace StockExchange_EGID.Server.Domain.Contracts
{
    /// <summary>
    /// The Unit of Work pattern is a design pattern used in software engineering
    /// to manage a group of operations that need to be performed as a single unit, 
    /// typically involving multiple repositories or data access operations. 
    /// The goal is to ensure that changes are committed or rolled back consistently.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User { get; }
        IGenericRepository<Stock> Stock { get; }
        IGenericRepository<StockHistory> StockHistory { get; }
        IGenericRepository<Order> Order { get; }

        public IDbContextTransaction BeginTransaction();
        // add more 
        Task<int> Complete();


        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {

        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {

        }

        
    }
}
