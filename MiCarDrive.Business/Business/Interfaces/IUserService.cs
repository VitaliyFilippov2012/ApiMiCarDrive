using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DBContext.Models;

namespace Business.Interfaces
{
    public interface IUsersService
    {
        Task<List<User>> GetAllUsersAsync();

        Task<User> GetUserByIdAsync(Guid idUser);

        Task<Guid> CreateNewUserAsync(User user);

        Task<Guid> GetUserByLoginAsync(string email);

        Task<bool> UpdateUserAsync(User user);
    }
}
