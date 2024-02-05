using Microsoft.AspNetCore.Identity;
using StockExchange_EGID.Server.Models;
using StockExchange_EGID.Server.Domain.Entities;
using StockExchange_EGID.Server.Models;
using StockExchange_EGID.Server.Utilities;

namespace StockExchange_EGID.Server.Domain.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public IEnumerable<User> GetAll();

        public void UpdateUserPassword(User user);
        public Task<UserManagerResponse> CreateUserAsync(User user);
        public Task<UserManagerResponse> LoginUserAsync(LoginDto model);
    }
}
