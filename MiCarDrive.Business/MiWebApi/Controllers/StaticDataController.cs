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
    public class StaticDataController : Controller
    {
        private readonly IUsersService _userService;
        private readonly IServicesService _serviceService;
        private readonly IEventsService _eventsService;

        public StaticDataController(IUsersService userService, IServicesService serviceService, IEventsService eventsService)
        {
            _userService = userService;
            _serviceService = serviceService;
            _eventsService = eventsService;
        }

        [HttpGet]
        [AuthenticationFilter]
        [Route("data/getStaticInfo")]
        public async Task<StaticDataWrapper> GetStaticData()
        {
            var userId = TokenServiceHelper.GetUserId(RequestHelper.GetTokenFromRequest(HttpContext.Request));
            if (string.IsNullOrWhiteSpace(userId))
                return null;
            var filter = new UserFilter()
            {
                UserId = new Guid(userId)
            };
            var user = (await _userService.GetUsersAsync(filter)).FirstOrDefault();
            var typeServices = await _serviceService.GetServiceTypes();
            var typeEvents = await _eventsService.GetTypeEventsAsync();
            var result = new StaticDataWrapper()
            {
                UserInfo = new UserInfo()
                {
                    UserId = user.UserId,
                    Birthday = user.Birthday,
                    City = user.City,
                    Lastname = user.Lastname,
                    Name = user.Name,
                    Patronymic = user.Patronymic,
                    Phone = user.Phone,
                    Gender = user.Gender,
                    PhotoArchiveId = user.PhotoArchiveId
                },
                TypeServices = typeServices.Select(x => new Shared.Models.Type() { Id = x.ServiceTypeId, Name = x.Name })
                    .ToList(),
                TypeEvents = typeEvents.Select(x => new Shared.Models.Type() { Id = x.EventTypeId, Name = x.Name })
                    .ToList(),
            };

            return result;
        }
    }
}
