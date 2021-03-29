using System;
using System.Threading.Tasks;
using Shared.Models;

namespace Business.Interfaces
{
    public interface IAuthService
    {
        Task<Guid> GetUserIdByPasswLoginAsync(string login, string password);
        Task<bool> RegisterUserAsync(UserCredentials credentials);
        Task<bool> UpdateUserCredentialsAsync(UserCredentials credentials);
    }
}
