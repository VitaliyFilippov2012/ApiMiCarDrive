using System;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using DBContext.Context;
using DBContext.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class AuthService : BaseService, IAuthService
    {
        public AuthService(DatabaseContext context) : base(context)
        {
        }

        public Task<Guid> GetUserByLoginAsync(string email)
        {
            return Context.Authentications.Where(x => x.Login == email).Select(x => x.UserId).FirstOrDefaultAsync();
        }

        public Task<Guid> GetUserIdByPasswLoginAsync(string login, string password)
        {
            return Context.Authentications.Where(x => x.Login == login && x.Password == password).Select(x => x.UserId).FirstOrDefaultAsync();
        }

        public Task<Authentication> GetUserByIdAsync(Guid id)
        {
            return Context.Authentications.Where(x => x.UserId == id).FirstOrDefaultAsync();
        }

        public async Task RegisterUserAsync(Authentication authentication)
        {
            if (AreCredentialsNotValid(authentication.Login, authentication.Password))
                return;

            await Context.Authentications.AddAsync(authentication);
            await Context.SaveChangesAsync();
        }

        private bool AreCredentialsNotValid(string login, string password)
        {
            return string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password);
        }

        public async Task<bool> UpdateUserCredentialsAsync(Authentication authentication)
        {
            var authUser = await Context.Authentications.Where(x => x.UserId == authentication.UserId).FirstOrDefaultAsync();
            if (authUser == null)
                return false;
            authUser.Password = authentication.Password;
            await Context.SaveChangesAsync();
            return true;
        }
    }
}
