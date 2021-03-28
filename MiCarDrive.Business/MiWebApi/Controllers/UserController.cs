using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Business.Filters;
using Business.Interfaces;
using MiWebApi.Aspects;
using MiWebApi.Helpers;
using Shared.Models;

namespace MiWebApi.Controllers
{
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUsersService _userService;

        public UserController(IUsersService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [AuthenticationFilter]
        [Route("user/name/{name}")]
        public async Task<UserInfo> GetUserByNameAsync(string name)
        {
            var filter = new UserFilter { UserName = name };
            return (await _userService.GetUsersAsync(filter)).FirstOrDefault();
        }

        [HttpGet]
        [AuthenticationFilter]
        [Route("user/id")]
        public async Task<UserInfo> GetUserById()
        {
            var headers = HttpContext.Request.Headers;
            if (!headers.TryGetValue("Token", out var token))
                return null;
            var userId = TokenServiceHelper.GetUserId(token);
            if (string.IsNullOrWhiteSpace(userId))
                return null;
            var filter = new UserFilter { UserId = new Guid(userId) };
            return (await _userService.GetUsersAsync(filter)).FirstOrDefault();
        }

        [HttpPut]
        [AuthenticationFilter]
        [Route("user")]
        public async Task<bool> UpdateUser([FromBody] UserInfo user)
        {
            var headers = HttpContext.Request.Headers;
            if (!headers.TryGetValue("Token", out var token))
                return false;
            var userId = TokenServiceHelper.GetUserId(token);
            if (string.IsNullOrWhiteSpace(userId))
                return false;
            return await _userService.UpdateUserAsync(user);
        }
    }
}
