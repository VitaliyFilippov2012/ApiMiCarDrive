using System;
using System.Threading.Tasks;
using DBContext.Models;

namespace Business.Interfaces
{
    public interface IAuthService
    {
        Task<Guid> GetUserIdByPasswLoginAsync(string login, string password);
        Task<Authentication> GetUserByIdAsync(Guid id);
        Task RegisterUserAsync(Authentication authentication);
        Task<bool> UpdateUserCredentialsAsync(Authentication authentication);
    }
}
