﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.AutoMapper;
using Business.Interfaces;
using DBContext.Context;
using DBContext.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using Refill = Shared.Models.Refill;
using Type = Shared.Models.Type;

namespace Business.Services
{
    public class EventsService : BaseService, IEventsService
    {
        private readonly IDetailsService _detailsService;

        public EventsService(DatabaseContext context, IDetailsService detailsService) : base(context)
        {
            _detailsService = detailsService;
        }

        public async Task<IEnumerable<Event>> GetCarEventsAsync(Guid carId)
        {
            var allCarEvents = Context.CarEvents.Include(x => x.UserCar).Where(x => x.UserCar.CarId == carId);
            var refillIds = allCarEvents.Join(Context.Refills, x => x.EventId, p => p.EventId, (x, p) => x.EventId);
            var serviceIds = allCarEvents.Join(Context.CarServices, x => x.EventId, p => p.EventId, (x, p) => x.EventId);
            return (await allCarEvents.Where(x => !refillIds.Union(serviceIds).Contains(x.EventId)).ToListAsync()).ToDtoList();
        }

        public async Task<IEnumerable<Refill>> GetCarRefillsEventsAsync(Guid carId)
        {
            var query = from e in Context.CarEvents
                join car in Context.UsersCars on e.UserCarId equals car.UserCarId
                join r in Context.Refills on e.EventId equals r.EventId
                where car.CarId == carId
                select e.ToRefillDto(r);
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<EventService>> GetCarServiceEventsAsync(Guid carId)
        {
            var query = from e in Context.CarEvents
                join car in Context.UsersCars on e.UserCarId equals car.UserCarId
                join s in Context.CarServices on e.EventId equals s.EventId
                where car.CarId == carId
                select e.ToServiceDto(s);
            var events = await query.ToListAsync();
            foreach (var e in events)
                e.Details = await _detailsService.GetDetailsByServiceId(e.ServiceId);

            return events;
        }
        
        public async Task<bool> DeleteCarEventAsync(Guid eventId)
        {
            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    var deleteEvent = await Context.CarEvents.Where(x => x.EventId == eventId).FirstOrDefaultAsync();
                    if (deleteEvent == null)
                        return false;
                    Context.CarEvents.Remove(deleteEvent);
                    await Context.SaveChangesAsync();
                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public async Task<bool> CreateCarFuelEventAsync(Refill refillEvent)
        {
            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    var carEvent = refillEvent.ToEntity();
                    await Context.CarEvents.AddAsync(carEvent);
                    var refill = refillEvent.ToRefillEntity();
                    refill.Event = carEvent;
                    await Context.Refills.AddAsync(refill);
                    await Context.SaveChangesAsync();
                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public async Task<bool> CreateCarServiceEventAsync(EventService serviceEvent)
        {
            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    await Context.CarEvents.AddAsync(serviceEvent.ToEntity());
                    await Context.SaveChangesAsync();
                    await Context.CarServices.AddAsync(serviceEvent.ToServiceEntity());
                    await Context.SaveChangesAsync();

                    if (serviceEvent.Details?.Any() == true)
                    {
                        var details = serviceEvent.Details.ToEntityList();
                        foreach (var detail in details)
                            await Context.Details.AddAsync(detail);
                        await Context.SaveChangesAsync();
                    }

                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public async Task<bool> CreateCarEventAsync(Event carEvent)
        {
            await Context.CarEvents.AddAsync(carEvent.ToEntity());
            await Context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCarFuelEventAsync(Refill refillEvent)
        {
            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    Context.CarEvents.Update(refillEvent.ToEntity());
                    Context.Refills.Update(refillEvent.ToRefillEntity());
                    await Context.SaveChangesAsync();
                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public async Task<bool> UpdateCarServiceEventAsync(EventService serviceEvent)
        {
            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    Context.CarEvents.Update(serviceEvent.ToEntity());
                    Context.CarServices.Update(serviceEvent.ToServiceEntity());

                    if (serviceEvent.Details?.Any() == true)
                    {
                        Context.Details.UpdateRange(serviceEvent.Details.ToEntityList());
                    }

                    await Context.SaveChangesAsync();
                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public async Task<bool> UpdateCarEventAsync(Event carEvent)
        {
            using (var transaction = Context.Database.BeginTransaction())
            {
                try
                {
                    Context.CarEvents.Update(carEvent.ToEntity());
                    await Context.SaveChangesAsync();
                    transaction.Commit();
                    return true;
                }
                catch
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public async Task<Event> GetEventByIdAsync(Guid idEvent)
        {
            return (await Context.CarEvents.Include(x=>x.UserCar).Where(x => x.EventId == idEvent).FirstOrDefaultAsync()).ToDto();
        }

        public async Task<Refill> GetFuelEventByIdAsync(Guid eventId)
        {
            return (await Context.CarEvents.Include(x => x.Refills).Where(x => x.EventId == eventId).FirstOrDefaultAsync()).ToRefillDto();
        }

        public async Task<EventService> GetServiceEventByIdAsync(Guid idEvent)
        {
            return (await Context.CarEvents.Include(x => x.CarServices).Include(nameof(DBContext.Models.Detail)).Where(x => x.EventId == idEvent).FirstOrDefaultAsync()).ToServiceDto();
        }

        public async Task<IEnumerable<Type>> GetTypeEventsAsync()
        {
            return (await Context.EventTypes.ToListAsync()).ToDtoList<EventType, Type>();
        }
    }
}
