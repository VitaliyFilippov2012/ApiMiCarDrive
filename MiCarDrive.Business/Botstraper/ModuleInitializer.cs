using Business.AutoMapper;
using Business.Interfaces;
using Business.Services;
using DBContext.Context;
using Microsoft.Extensions.DependencyInjection;

namespace Botstraper
{
    public static class ModuleInitializer
    {
        public static void ConfigureIoC(IServiceCollection services)
        {
            AutoMapperConfig.Initialize();
            services.AddScoped<DatabaseContext, DatabaseContext>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IEmailService, EmailService>();
            //services.AddScoped<ICarsService, CarsService>();
            services.AddScoped<IServicesService, ServicesService>();
            //services.AddScoped<IDetailsService, DetailsService>();
            //services.AddScoped<IEventsService, EventsService>();
            //services.AddScoped<IAuditService, AuditService>();
            //services.AddScoped<ISoapService, SoapService>();
            //services.AddScoped<ICryptographyService, CryptographyService>();
        }
    }
}
