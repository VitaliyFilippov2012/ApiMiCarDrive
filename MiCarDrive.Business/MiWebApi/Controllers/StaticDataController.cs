using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using MiWebApi.Aspects;
using MiWebApi.Helpers;
using Shared.Filters;
using Shared.Models;

namespace MiWebApi.Controllers
{
    [ApiController]
    public class StaticDataController : Controller
    {
        private readonly IUsersService _userService;
        private readonly IServicesService _serviceService;
        private readonly IEventsService _eventsService;
        private readonly IReferenceService _referenceService;

        public StaticDataController(IUsersService userService, IServicesService serviceService, IEventsService eventsService, IReferenceService referenceService)
        {
            _userService = userService;
            _serviceService = serviceService;
            _eventsService = eventsService;
            _referenceService = referenceService;
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
            var result = new StaticDataWrapper()
            {
                UserInfo = user,
                ServiceTypes = await _serviceService.GetServiceTypes(),
                EventTypes = await _eventsService.GetTypeEventsAsync(),
                TransmissionTypes = await _referenceService.GetTransmissionTypesAsync(),
                FuelTypes = await _referenceService.GetFuelTypesAsync(),
                Roles = await _referenceService.GetUserRolesAsync(),
                Rights = await _referenceService.GetUserRightsAsync()
            };

            return result;
        }
    }
}
