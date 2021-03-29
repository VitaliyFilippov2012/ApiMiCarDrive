using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.AutoMapper;
using Business.Heplers;
using Business.Interfaces;
using DBContext.Context;
using Microsoft.EntityFrameworkCore;
using Shared.Filters;
using Shared.Models;

namespace Business.Services
{
    public class UsersService : BaseService, IUsersService
    {
        public UsersService(DatabaseContext context) : base(context)
        {
        }

        public async Task<IEnumerable<UserInfo>> GetUsersAsync(UserFilter userFilter)
        {
            return (await Context.Users.Where(userFilter).ToListAsync()).ToDtoList();
        }

        public async Task<Guid> CreateNewUserAsync(UserInfo user)
        {
            if (user.UserId == Guid.Empty)
                user.UserId = Guid.NewGuid();
            await Context.Users.AddAsync(user.ToEntity());
            return user.UserId;
        }

        public Task<Guid> GetUserIdByLoginAsync(string email)
        {
            return Context.Authentications.Where(x => x.Login == email).Select(x => x.UserId).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateUserAsync(UserInfo user)
        {
            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    Context.Users.Update(user.ToEntity());
                    await Context.SaveChangesAsync();
                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }
    }
}
