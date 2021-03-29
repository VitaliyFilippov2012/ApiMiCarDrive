﻿using Microsoft.AspNetCore.Mvc;
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
                TypeServices = await _serviceService.GetServiceTypes(),
                TypeEvents = await _eventsService.GetTypeEventsAsync()
            };

            return result;
        }
    }
}
