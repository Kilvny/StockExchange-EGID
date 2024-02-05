﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using StockExchange_EGID.Server.DataAccess.EFCore;
using StockExchange_EGID.Server.Domain.Contracts;
using StockExchange_EGID.Server.Domain.Entities;

namespace StockExchange_EGID.Server.Repositories.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<UnitOfWork> _logger;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private IUserRepository _user;


        public UnitOfWork(ApplicationContext context, ILogger<UnitOfWork> logger, UserManager<User> userManager, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
            _configuration = configuration;
        }
        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_context, _logger, _userManager, _configuration);
                }
                return _user;
            }
        }
        //public IDepartmentRepository Department
        //{
        //    get
        //    {
        //        if (_department == null)
        //        {
        //            _department = new DepartmentRepository(_context);
        //        }
        //        return _department;
        //    }
        //}

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }
        public async Task<int> Complete()
        {
            var saveResult = await _context.SaveChangesAsync();
            _logger.LogInformation($"Saved {saveResult} to the database successfully!") ;
            return saveResult;
            
        }
        // Flag: Has Dispose already been called?
        bool disposed = false;

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            _context.Dispose();
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        ~UnitOfWork()
        {
            Dispose(disposing: false);
        }

    }
}
