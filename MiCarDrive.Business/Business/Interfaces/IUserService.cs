using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Filters;
using Shared.Models;

namespace Business.Interfaces
{
    public interface IUsersService
    {
        Task<IEnumerable<UserInfo>> GetUsersAsync(UserFilter userFilter);

        Task<Guid> CreateNewUserAsync(UserInfo user);

        Task<Guid> GetUserIdByLoginAsync(string email);

        Task<bool> UpdateUserAsync(UserInfo user);
    }
}
