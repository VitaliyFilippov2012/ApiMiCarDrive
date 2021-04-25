using AutoMapper;
using DBContext.Models;
using Shared.Models;
using Car = Shared.Models.Car;
using Detail = DBContext.Models.Detail;
using Refill = DBContext.Models.Refill;

namespace Business.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static IMapper Mapper { get; set; }

        public static void Initialize()
        {
            var cfg = new MapperConfiguration(
                x =>
                {
                    x.AddProfile<MappingProfile>();
                    x.AllowNullCollections = true;
                    x.SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
                    x.DestinationMemberNamingConvention = new PascalCaseNamingConvention();
                });

            Mapper = cfg.CreateMapper();
        }

        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                UserMapping();
                EventMapping();
                CarMapping();
                DetailMapping();
                ReferenceDataMapping();
            }

            private void UserMapping()
            {
                CreateMap<User, UserInfo>();
                CreateMap<UserInfo, User>();
            }

            private void ReferenceDataMapping()
            {
                CreateMap<TransmissionType, Type>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TransmissionTypeId));
                CreateMap<FuelType, Type>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.FuelTypeId));
                CreateMap<Role, Type>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RoleId));
                CreateMap<Right, Type>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RightId));
            }

            private void CarMapping()
            {
                CreateMap<DBContext.Models.Car, Car>();
                CreateMap<Car, DBContext.Models.Car>();
            }

            private void DetailMapping()
            {
                CreateMap<Shared.Models.Detail, Detail>();
                CreateMap<Detail, Shared.Models.Detail>();
            }

            private void EventMapping()
            {
                CreateMap<CarEvent, Event>()
                    .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserCar.UserId))
                    .ForMember(dest => dest.CarId, opt => opt.MapFrom(src => src.UserCar.CarId));

                CreateMap<ServiceType, Type>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ServiceTypeId));

                CreateMap<EventType, Type>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EventTypeId));

                CreateMap<Event, CarEvent>();

                CreateMap<CarEvent, Shared.Models.Refill>()
                    .IncludeBase<CarEvent, Event>();

                CreateMap<CarEvent, EventService>()
                    .IncludeBase<CarEvent, Event>();

                CreateMap<EventService, CarService>();

                CreateMap<EventService, CarEvent>();

                CreateMap<Shared.Models.Refill, Refill>();

                CreateMap<Shared.Models.Refill, CarEvent>();
            }
        }
    }
}
