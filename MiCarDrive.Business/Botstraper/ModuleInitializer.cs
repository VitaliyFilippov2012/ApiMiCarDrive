using Business.AutoMapper;
using Business.Interfaces;
using Business.Services;
using DBContext.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Botstraper
{
    public static class ModuleInitializer
    {
        public static void Initialize(IServiceCollection services)
        {
            AutoMapperConfig.Initialize();
            ConfigureIoC(services);
        }

        private static void ConfigureIoC(IServiceCollection services)
        {
            services.AddScoped<DatabaseContext, DatabaseContext>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ICarsService, CarService>();
            services.AddScoped<IServicesService, ServicesService>();
            services.AddScoped<IDetailsService, DetailsService>();
            services.AddScoped<IEventsService, EventsService>();
            services.AddScoped<IReferenceService, ReferenceService>();
            services.AddScoped<IAuditService, AuditService>();
            services.AddScoped<ICryptographyService, CryptographyService>();
        }
    }
}
