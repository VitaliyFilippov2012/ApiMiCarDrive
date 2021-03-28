using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using DBContext.Context;
using DBContext.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class UsersService : BaseService, IUsersService
    {
        public UsersService(DatabaseContext context) : base(context)
        {
        }

        public Task<List<User>> GetAllUsersAsync()
        {
            return Context.Users.ToListAsync();
        }

        public Task<User> GetUserByIdAsync(Guid idUser)
        {
            return Context.Users.Where(x => x.UserId == idUser).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Car>> GetUserCarsByUserIdAsync(Guid idUser)
        {
            return await Context.UsersCars.Where(x => x.UserId == idUser).Select(x => x.Car).ToListAsync();
        }

        public async Task<Guid> CreateNewUserAsync(User user)
        {
            if (user.UserId == Guid.Empty)
                user.UserId = Guid.NewGuid();
            await Context.Users.AddAsync(user);
            return user.UserId;
        }

        public Task<Guid> GetUserByLoginAsync(string email)
        {
            return Context.Authentications.Where(x => x.Login == email).Select(x => x.UserId).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateUserAsync(User user)
        {
            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    Context.Users.Update(user);
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
