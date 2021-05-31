using Business.Interfaces;
using DBContext.Context;
using Microsoft.EntityFrameworkCore;
using Shared.Enums;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services
{
    public class AuditService : BaseService, IAuditService
    {
        public AuditService(DatabaseContext context) : base(context)
        {
        }

        public async Task<List<SyncEntity>> GetAllEventsByTypeAfterDate(Guid userId, string lastDateSync, ActionType type)
        {
            var dateSync = ParseToDateTime(lastDateSync);
            var actions = await Context.ActionAudits.Where(x => x.UserId == userId && x.Action == type.ToString())
                .ToListAsync();
            return actions.Where(x => ParseToDateTime(x.DateUpdate).CompareTo(dateSync) == 1).Select(x => new SyncEntity() { EntityId = x.EntityId, EntityName = x.Entity, ActionDate = x.DateUpdate, ActionSide = ActionSide.Server.ToString() }).ToList();

        }

        public Task<bool> ExistsInfoToSync(string lastDateSync, Guid userId)
        {
            var dateSync = ParseToDateTime(lastDateSync);
            return Context.ActionAudits.Where(x => x.UserId == userId).Select(x => ParseToDateTime(x.DateUpdate)).Where(x => x.CompareTo(dateSync) == 1).AnyAsync();
        }

        private static DateTime ParseToDateTime(string lastDateSync)
        {
            if (lastDateSync.Length > 19)
                lastDateSync = lastDateSync.Remove(19);
            return DateTime.ParseExact(lastDateSync, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
