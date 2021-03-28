using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Business.Interfaces;
using DBContext.Models;
using MiWebApi.Helpers;
using Shared.Models;

namespace MiWebApi.Controllers
{
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IUsersService _userService;
        private readonly IEmailService _emailService;

        public AuthController(IAuthService authService, IUsersService userService, IEmailService emailService)
        {
            _authService = authService;
            _userService = userService;
            _emailService = emailService;
        }

        [HttpPost]
        [Route("auth/user")]
        public async Task<string> RegisterUser([FromBody] UserCredentials user)
        {
            var userId = await _userService.CreateNewUserAsync(new User()
            {
                City = "City",
                Birthday = new DateTime(1900, 12, 31),
                Name = "Name",
                Lastname = "Lastname",
                Patronymic = "Patronymic",
                Gender = "m",
                Phone = "+375(__) ___-__-__"
            });

            await _authService.RegisterUserAsync(new Authentication()
            {
                UserId = userId,
                Password = user.Password,
                Login = user.Login
            });

            return "OK";
        }

        [HttpPost]
        [Route("auth/login")]
        public async Task<IActionResult> GetUserId([FromBody] UserCredentials userCredentials)
        {
            var token = await TokenServiceHelper.GetTokenAsync(userCredentials, _authService);
            if (token == null)
                return BadRequest(new { errorText = "Invalid login or password." });
            return Json(token);
        }

        [HttpPut]
        [Route("auth/updatePassw")]
        public async Task<bool> UpdateUserCredentials([FromBody] UserCredentials userCredentials)
        {
            var userId = await _userService.GetUserByLoginAsync(userCredentials.Login);
            if (userId == Guid.Empty)
                return false;
            var encryptMessage = userCredentials.Password.Split("MiCarDrive");
            var message = $"Your new password: {encryptMessage[1]}";
            if (await _authService.UpdateUserCredentialsAsync(new Authentication { Password = encryptMessage[0], UserId = userId}))
            {
                await _emailService.SendEmailMessageAsync(message, userCredentials.Login);
            }

            return true;
        }
    }
}
