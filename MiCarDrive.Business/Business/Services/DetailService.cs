using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Interfaces;
using DBContext.Context;
using DBContext.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class DetailsService : BaseService, IDetailsService
    {
        public DetailsService(DatabaseContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Detail>> GetDetailsByServiceId(Guid serviceId)
        {
            return await Context.Details.Where(x => x.ServiceId == serviceId).ToListAsync();
        }
    }
}
