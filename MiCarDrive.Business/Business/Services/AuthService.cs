using System;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using DBContext.Context;
using DBContext.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Business.Services
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IUsersService _usersService;
        private readonly IEmailService _emailService;

        public AuthService(DatabaseContext context, IUsersService usersService, IEmailService emailService) : base(context)
        {
            _usersService = usersService;
            _emailService = emailService;
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

        public async Task<bool> RegisterUserAsync(UserCredentials credentials)
        {
            if (AreCredentialsNotValid(credentials))
                return false;

            var userId = await _usersService.CreateNewUserAsync(new UserInfo()
            {
                City = "City",
                Birthday = new DateTime(1900, 12, 31),
                Name = "Name",
                Lastname = "Lastname",
                Patronymic = "Patronymic",
                Gender = "m",
                Phone = "+375(__) ___-__-__"
            });

            var authentication = new Authentication
            {
                Login = credentials.Login,
                Password = credentials.Password,
                UserId = userId
            };
            await Context.Authentications.AddAsync(authentication);
            await Context.SaveChangesAsync();
            return true;
        }

        private bool AreCredentialsNotValid(UserCredentials credentials)
        {
            return string.IsNullOrEmpty(credentials.Login) || string.IsNullOrEmpty(credentials.Password);
        }

        public async Task<bool> UpdateUserCredentialsAsync(UserCredentials credentials)
        {
            if (AreCredentialsNotValid(credentials))
                return false;
            var userId = await _usersService.GetUserIdByLoginAsync(credentials.Login);
            var authUser = await Context.Authentications.Where(x => x.UserId == userId).FirstOrDefaultAsync();
            if (authUser == null)
                return false;
            authUser.Password = credentials.Password;
            await Context.SaveChangesAsync();
            var encryptMessage = credentials.Password.Split("MiCarDrive");
            var message = $"Your new password: {encryptMessage[1]}";
            await _emailService.SendEmailMessageAsync(message, credentials.Login);
            return true;
        }
    }
}
