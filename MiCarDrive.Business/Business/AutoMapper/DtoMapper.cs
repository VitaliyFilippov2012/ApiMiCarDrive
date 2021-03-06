using System;
using System.Collections.Generic;
using System.Linq;
using DBContext.Models;
using Shared.Models;
using Car = DBContext.Models.Car;
using Detail = Shared.Models.Detail;
using Refill = Shared.Models.Refill;
using Type = System.Type;

namespace Business.AutoMapper
{
    public static class DtoMapper
    {
        public static IEnumerable<T> ToDtoList<TE, T>(this IEnumerable<TE> source)
        {
            return source.Select(item => ToDto<TE, T>(item));
        }

        private static T ToDto<TE, T>(this TE item)
        {
            return AutoMapperConfig.Mapper.Map<TE, T>(item);
        }

        private static T ToDto<TE, T>(this TE item, T destination)
        {
            return AutoMapperConfig.Mapper.Map(item, destination);
        }

        public static Shared.Models.Car ToDto(this Car car)
        {
            return ToDto<Car, Shared.Models.Car>(car);
        }

        public static Shared.Models.Car ToDto(this Car car, IEnumerable<UserInfo> users)
        {
            var dto = ToDto<Car, Shared.Models.Car>(car);
            dto.Users = users;
            return dto;
        }

        public static IEnumerable<Shared.Models.Car> ToDtoList(this IEnumerable<Car> cars)
        {
            return cars.Select(x=>x.ToDto());
        }

        public static Car ToEntity(this Shared.Models.Car car)
        {
            return ToDto<Shared.Models.Car, Car>(car);
        }

        public static Car ToEntity(this Shared.Models.Car car, Car entity)
        {
            return ToDto(car, entity);
        }

        public static UserInfo ToDto(this User user, string email)
        {
            var userInfo = ToDto<User, UserInfo>(user);
            userInfo.Email = email;
            return userInfo;
        }

        public static UserInfo ToDto(this User user, Guid userCarId)
        {
            var dto = ToDto<User, UserInfo>(user);
            dto.UserCarId = userCarId;
            return dto;
        }

        public static UserInfo ToDto(this User user, Guid userCarId, string email, IEnumerable<Guid> rightIds, Guid? roleId)
        {
            var dto = ToDto<User, UserInfo>(user);
            dto.UserCarId = userCarId;
            dto.RightIds = rightIds;
            dto.Email = email;
            dto.RoleId = roleId.GetValueOrDefault();
            return dto;
        }

        public static User ToEntity(this UserInfo userInfo)
        {
            return ToDto<UserInfo, User>(userInfo);
        }

        public static CarEvent ToEntity(this EventService carEvent)
        {
            return ToDto<EventService, CarEvent>(carEvent);
        }

        public static CarService ToServiceEntity(this EventService carEvent)
        {
            return ToDto<EventService, CarService>(carEvent);
        }

        public static CarEvent ToEntity(this Refill refill)
        {
            return ToDto<Refill, CarEvent>(refill);
        }

        public static DBContext.Models.Refill ToRefillEntity(this Refill refill)
        {
            return ToDto<Refill, DBContext.Models.Refill>(refill);
        }

        public static Event ToDto(this CarEvent carEvent)
        {
            return ToDto<CarEvent, Event>(carEvent);
        }

        public static CarEvent ToEntity(this Event carEvent)
        {
            return ToDto<Event, CarEvent>(carEvent);
        }

        public static IEnumerable<Event> ToDtoList(this IEnumerable<CarEvent> carEvents)
        {
            return carEvents.ToDtoList<CarEvent, Event>();
        }

        public static IEnumerable<Detail> ToDtoList(this IEnumerable<DBContext.Models.Detail> details)
        {
            return details.ToDtoList<DBContext.Models.Detail, Detail>();
        }

        public static IEnumerable<DBContext.Models.Detail> ToEntityList(this IEnumerable<Detail> details)
        {
            return details.ToDtoList<Detail, DBContext.Models.Detail>();
        }

        public static Refill ToRefillDto(this CarEvent carEvent)
        {
            var refillDto = ToDto<CarEvent, Refill>(carEvent);
            var refill = carEvent.Refills.First();
            refillDto.Volume = refill.Volume;
            refillDto.RefillId = refill.RefillId;
            return refillDto;
        }

        public static Refill ToRefillDto(this CarEvent carEvent, DBContext.Models.Refill refill)
        {
            var refillDto = ToDto<CarEvent, Refill>(carEvent);
            refillDto.Volume = refill.Volume;
            refillDto.RefillId = refill.RefillId;
            return refillDto;
        }

        public static IEnumerable<Refill> ToRefillDtoList(this IEnumerable<CarEvent> carEvents)
        {
            return carEvents.Select(x=>x.ToRefillDto());
        }

        public static EventService ToServiceDto(this CarEvent carEvent)
        {
            var serviceDto = ToDto<CarEvent, EventService>(carEvent);
            var service = carEvent.CarServices.First();
            serviceDto.RepeatInterval = service.RepeatInterval;
            serviceDto.ServiceId = service.ServiceId;
            serviceDto.ServiceTypeId = service.ServiceTypeId;
            serviceDto.Details = service.Details?.ToDtoList() ?? new List<Detail>();
            return serviceDto;
        }

        public static EventService ToServiceDto(this CarEvent carEvent, CarService service)
        {
            var serviceDto = ToDto<CarEvent, EventService>(carEvent);
            serviceDto.RepeatInterval = service.RepeatInterval;
            serviceDto.ServiceId = service.ServiceId;
            serviceDto.ServiceTypeId = service.ServiceTypeId;
            serviceDto.Details = service.Details?.ToDtoList() ?? new List<Detail>();
            return serviceDto;
        }

        public static IEnumerable<EventService> ToServiceDtoList(this IEnumerable<CarEvent> carEvents)
        {
            return carEvents.Select(x => x.ToServiceDto());
        }
    }
}
