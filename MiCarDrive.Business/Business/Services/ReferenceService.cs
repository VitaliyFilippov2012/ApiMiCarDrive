using System.Collections.Generic;
using System.Threading.Tasks;
using Business.AutoMapper;
using Business.Interfaces;
using DBContext.Context;
using DBContext.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class ReferenceService : BaseService, IReferenceService
    {
        public ReferenceService(DatabaseContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Shared.Models.Type>> GetTransmissionTypesAsync()
        {
            return (await Context.TransmissionTypes.ToListAsync()).ToDtoList<TransmissionType, Shared.Models.Type>();
        }

        public async Task<IEnumerable<Shared.Models.Type>> GetFuelTypesAsync()
        {
            return (await Context.FuelTypes.ToListAsync()).ToDtoList<FuelType, Shared.Models.Type>();

        }

        public async Task<IEnumerable<Shared.Models.Type>> GetUserRolesAsync()
        {
            return (await Context.Roles.ToListAsync()).ToDtoList<Role, Shared.Models.Type>();
        }

        public async Task<IEnumerable<Shared.Models.Type>> GetUserRightsAsync()
        {
            return (await Context.Rights.ToListAsync()).ToDtoList<Right, Shared.Models.Type>();

        }
    }
}
