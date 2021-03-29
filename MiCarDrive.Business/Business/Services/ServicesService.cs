using System.Collections.Generic;
using System.Threading.Tasks;
using Business.AutoMapper;
using Business.Interfaces;
using DBContext.Context;
using DBContext.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Business.Services
{
    public class ServicesService : BaseService, IServicesService
    {
        public ServicesService(DatabaseContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Type>> GetServiceTypes()
        {
            return (await Context.ServiceTypes.ToListAsync()).ToDtoList<ServiceType, Type>();
        }
    }
}
