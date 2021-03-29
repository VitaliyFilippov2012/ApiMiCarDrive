using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DBContext.Models;
using Shared.Models;
using Type = Shared.Models.Type;

namespace Business.Interfaces
{
    public interface IEventsService
    {
        Task<IEnumerable<Event>> GetCarEventsAsync(Guid carId);

        Task<CarEvent> GetEventByIdAsync(Guid id);

        Task<EventService> GetServiceEventByIdAsync(Guid idEvent);

        Task<Shared.Models.Refill> GetFuelEventByIdAsync(Guid idEvent);

        Task<IEnumerable<Type>> GetTypeEventsAsync();

        Task<IEnumerable<Shared.Models.Refill>> GetCarFuelsEventsAsync(Guid carId);

        Task<IEnumerable<EventService>> GetCarServiceEventsAsync(Guid carId);

        Task<bool> DeleteCarEventAsync(Guid eventId);

        Task<bool> CreateCarFuelEventAsync(Shared.Models.Refill fuelEvent);

        Task<bool> CreateCarServiceEventAsync(EventService serviceEvent);

        Task<bool> CreateCarEventAsync(Event carEvent);

        Task<bool> UpdateCarFuelEventAsync(Shared.Models.Refill RefillEvent);

        Task<bool> UpdateCarServiceEventAsync(EventService serviceEvent);

        Task<bool> UpdateCarEventAsync(Event carEvent);
    }
}
