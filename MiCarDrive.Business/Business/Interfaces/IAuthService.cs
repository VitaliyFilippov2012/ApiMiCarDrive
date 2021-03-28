using System;
using System.Threading.Tasks;
using DBContext.Models;
using Shared.Models;

namespace Business.Interfaces
{
    public interface IAuthService
    {
        Task<Guid> GetUserIdByPasswLoginAsync(string login, string password);
        Task<Authentication> GetUserByIdAsync(Guid id);
        Task<bool> RegisterUserAsync(UserCredentials credentials);
        Task<bool> UpdateUserCredentialsAsync(UserCredentials credentials);
    }
}
