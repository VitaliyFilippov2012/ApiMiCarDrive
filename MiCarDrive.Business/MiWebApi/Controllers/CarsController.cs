using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Interfaces;
using MiWebApi.Aspects;
using MiWebApi.Helpers;
using Shared.Models;

namespace MiWebApi.Controllers
{
    [ApiController]
    public class CarsController : Controller
    {
        private readonly ICarsService _carsService;

        public CarsController(ICarsService carsService)
        {
            _carsService = carsService;
        }

        [HttpGet]
        [AuthenticationFilter]
        [Route("cars/userId")]
        public async Task<IEnumerable<Car>> GetCarsAsync()
        {
            if (!Validate()) return null;
            var userId = TokenServiceHelper.GetUserId(RequestHelper.GetTokenFromRequest(HttpContext.Request));
            if (string.IsNullOrWhiteSpace(userId))
                return null;
            return await _carsService.GetAllUserCarsAsync(Guid.Parse(userId));
        }

        [HttpGet]
        [AuthenticationFilter]
        [Route("car/users")]
        public async Task<IEnumerable<Car>> GetCarUsersAsync()
        {
            if (!Validate()) return null;
            var userId = TokenServiceHelper.GetUserId(RequestHelper.GetTokenFromRequest(HttpContext.Request));
            if (string.IsNullOrWhiteSpace(userId))
                return null;
            return await _carsService.GetAllUserCarsAsync(Guid.Parse(userId));
        }

        [HttpGet]
        [AuthenticationFilter]
        [Route("car/{carId}")]
        public Task<Car> GetCarByIdName(Guid carId)
        {
            if (!Validate()) return null;
            return _carsService.GetCarByIdAsync(carId);
        }

        [HttpPost]
        [AuthenticationFilter]
        [Route("car")]
        public async Task<Guid?> CreateCar([FromBody] Car car)
        {
            if (!Validate()) return null;
            var userId = TokenServiceHelper.GetUserId(RequestHelper.GetTokenFromRequest(HttpContext.Request));
            if (string.IsNullOrWhiteSpace(userId))
                return null;
            return await _carsService.CreateCarAsync(car, Guid.Parse(userId));
        }

        [HttpPost]
        [AuthenticationFilter]
        [Route("car/shareCar/{carId}&{email}")]
        public async Task<UserInfo> ShareCar(Guid carId, string email)
        {
            if (!Validate()) return null;
            return await _carsService.ShareCarWithOtherUserAsync(carId, email);
        }

        private bool Validate()
        {
            var userId = TokenServiceHelper.GetUserId(RequestHelper.GetTokenFromRequest(HttpContext.Request));
            if (string.IsNullOrWhiteSpace(userId))
                return false;
            return true;
        }

        [HttpGet]
        [Route("addShareCar/{json}")]
        public async Task<IActionResult> AddSharingCar(string json)
        {
            if (await _carsService.AddShareCarAsync(json))
                return View("CarAddedView");
            return View("OopsView");
        }

        [HttpDelete]
        [AuthenticationFilter]
        [Route("deleteShareCar/{carId}")]
        public async Task<bool> DeleteShareCar(Guid carId)
        {
            if (!Validate()) return false;
            var userId = TokenServiceHelper.GetUserId(RequestHelper.GetTokenFromRequest(HttpContext.Request));
            if (string.IsNullOrWhiteSpace(userId))
                return false;
            return await _carsService.DeleteShareCarAsync(carId, Guid.Parse(userId));
        }

        [HttpPut]
        [AuthenticationFilter]
        [Route("car")]
        public async Task<bool> UpdateCar([FromBody] Car car)
        {
            if (!Validate()) return false;
            return await _carsService.UpdateCarAsync(car);
        }
    }
}
