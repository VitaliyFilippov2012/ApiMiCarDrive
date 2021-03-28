using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Interfaces;
using DBContext.Context;
using DBContext.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class ServicesService : BaseService, IServicesService
    {
        public ServicesService(DatabaseContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ServiceType>> GetServiceTypes()
        {
            return await Context.ServiceTypes.ToListAsync();
        }
    }
}
