using System;
using System.Threading.Tasks;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MiWebApi.Aspects;
using Shared.Models;

namespace MiWebApi.Controllers
{
    [ApiController]
    public class EventsController : Controller
    {
        private readonly IEventsService _eventsService;

        public EventsController(IEventsService eventsService)
        {
            _eventsService = eventsService;
        }

        [HttpGet]
        [AuthenticationFilter]
        [Route("events/carId/{carId:guid}")]
        public async Task<EventsWrapper> GetAllCarEventsAsync(Guid carId)
        {
            return new EventsWrapper
            {
                Events = await _eventsService.GetCarEventsAsync(carId),
                Refills = await _eventsService.GetCarRefillsEventsAsync(carId),
                EventServices = await _eventsService.GetCarServiceEventsAsync(carId)
            };
        }

        [HttpGet]
        [AuthenticationFilter]
        [Route("event/{eventId}")]
        public async Task<Event> GetEventById(Guid eventId)
        {
            return await _eventsService.GetEventByIdAsync(eventId);
        }

        [HttpGet]
        [AuthenticationFilter]
        [Route("refill/{eventId}")]
        public async Task<Refill> GetRefillById(Guid eventId)
        {
            return await _eventsService.GetFuelEventByIdAsync(eventId);
        }

        [HttpGet]
        [AuthenticationFilter]
        [Route("service/{eventId}")]
        public async Task<EventService> GetServicesById(Guid eventId)
        {
            return await _eventsService.GetServiceEventByIdAsync(eventId);
        }

        [HttpPost]
        [AuthenticationFilter]
        [Route("create/event")]
        public async Task<bool> CreateEvent([FromBody] Event carEvent)
        {
            return await _eventsService.CreateCarEventAsync(carEvent);
        }

        [HttpPost]
        [AuthenticationFilter]
        [Route("create/refill")]
        public async Task<bool> CreateFuel([FromBody] Refill refillEvent)
        {
            return await _eventsService.CreateCarFuelEventAsync(refillEvent);
        }

        [HttpPost]
        [AuthenticationFilter]
        [Route("create/service")]
        public async Task<bool> CreateServices([FromBody] EventService eventService)
        {
            return await _eventsService.CreateCarServiceEventAsync(eventService);
        }

        [HttpPut]
        [AuthenticationFilter]
        [Route("update/event")]
        public async Task<bool> UpdateEvent([FromBody] Event carEvent)
        {
            return await _eventsService.UpdateCarEventAsync(carEvent);
        }

        [HttpPut]
        [AuthenticationFilter]
        [Route("update/refill")]
        public async Task<bool> UpdateFuel([FromBody] Refill refillEvent)
        {
            return await _eventsService.UpdateCarFuelEventAsync(refillEvent);
        }

        [HttpPut]
        [AuthenticationFilter]
        [Route("update/service")]
        public async Task<bool> UpdateServices([FromBody] EventService eventService)
        {
            return await _eventsService.UpdateCarServiceEventAsync(eventService);
        }

        [HttpDelete]
        [AuthenticationFilter]
        [Route("event/{eventId}")]
        public async Task<bool> DeleteEventById(Guid eventId)
        {
            return await _eventsService.DeleteCarEventAsync(eventId);
        }
    }
}
