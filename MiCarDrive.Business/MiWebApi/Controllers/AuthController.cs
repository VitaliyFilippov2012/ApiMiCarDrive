using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Business.Interfaces;
using MiWebApi.Helpers;
using Shared.Models;

namespace MiWebApi.Controllers
{
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("auth/user")]
        public async Task<IActionResult> RegisterUser([FromBody] UserCredentials credentials)
        {
            if(await _authService.RegisterUserAsync(credentials))
                return Ok();
            return BadRequest();
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
        public async Task<IActionResult> UpdateUserCredentials([FromBody] UserCredentials userCredentials)
        {
            if (await _authService.UpdateUserCredentialsAsync(userCredentials))
                return Ok();
            return BadRequest();
        }
    }
}
