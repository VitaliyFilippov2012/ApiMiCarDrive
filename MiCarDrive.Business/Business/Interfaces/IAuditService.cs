using Shared.Enums;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IAuditService
    {
        Task<List<SyncEntity>> GetAllEventsByTypeAfterDate(Guid userId, string lastDateSync, ActionType type);
    }
}
