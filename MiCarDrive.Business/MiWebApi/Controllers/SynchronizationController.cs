using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiWebApi.Aspects;
using MiWebApi.Helpers;
using Shared.Enums;
using Shared.Models;

namespace MiWebApi.Controllers
{
    [ApiController]
    public class SynchronizationController : Controller
    {
        private readonly IAuditService _auditService;
        private readonly ICarsService _carsService;
        private readonly IEventsService _eventsService;

        public SynchronizationController(IAuditService auditService, ICarsService carsService, IEventsService eventsService)
        {
            _auditService = auditService;
            _carsService = carsService;
            _eventsService = eventsService;
        }

        [HttpPost]
        [AuthenticationFilter]
        [Route("synchronizationContract")]
        public async Task<SynchronizationContract> GetSynchronizationContract([FromBody] SynchronizationClientDataContract clientSynchronizationDataContract)
        {
            var userIdString = TokenServiceHelper.GetUserId(RequestHelper.GetTokenFromRequest(HttpContext.Request));
            if (string.IsNullOrWhiteSpace(userIdString))
                return null;
            var userId = new Guid(userIdString);
            if (clientSynchronizationDataContract?.LastSyncDate == null)
                return null;
            PrepareDataForSynchronization(clientSynchronizationDataContract);
            await DeleteEntitiesFromServer(userId, clientSynchronizationDataContract.Delete);
            var finalDeleteAction = await GetDeleteActions(userId, clientSynchronizationDataContract);

            var deleteEntitiesIds = finalDeleteAction.Union(clientSynchronizationDataContract.Delete).Select(x => x.EntityId).ToList();
            var putAction = await GetPutActionsWithoutDeleteActionsByIds(userId, clientSynchronizationDataContract.LastSyncDate, clientSynchronizationDataContract.Put, deleteEntitiesIds);
            var postAction = await GetPostActionsWithoutDeleteActionsByIds(userId, clientSynchronizationDataContract.LastSyncDate, clientSynchronizationDataContract.Post, deleteEntitiesIds);


            var synchronizationDataMembers = finalDeleteAction.Select(x => ToSynchronizationDataMember(x, ActionType.DELETE)).ToList().Union(postAction.Select(x => ToSynchronizationDataMember(x, ActionType.POST)).ToList().Union(putAction.Select(x => ToSynchronizationDataMember(x, ActionType.PUT)).ToList())).ToList();
            var newLastDateSync = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return new SynchronizationContract()
            { SynchronizationDataMembers = synchronizationDataMembers, LastSyncDate = newLastDateSync };
        }

        private void PrepareDataForSynchronization(SynchronizationClientDataContract clientSynchronizationDataContract)
        {
            clientSynchronizationDataContract.Delete ??= new List<SyncEntity>();
            clientSynchronizationDataContract.Put ??= new List<SyncEntity>();
            clientSynchronizationDataContract.Post ??= new List<SyncEntity>();
        }

        private static SynchronizationDataMember ToSynchronizationDataMember(SyncEntity x, ActionType actionType)
        {
            return new SynchronizationDataMember()
            {
                ActionDate = x.ActionDate,
                ActionSide = x.ActionSide,
                EntityId = x.EntityId,
                ActionType = actionType.ToString(),
                Entity = x.EntityName
            };
        }

        private async Task<List<SyncEntity>> GetPostActionsWithoutDeleteActionsByIds(Guid userId,
            string syncDate, IEnumerable<SyncEntity> clientPostAction, ICollection<Guid> deleteEntitiesIds)
        {
            return (await _auditService.GetAllEventsByTypeAfterDate(userId, syncDate, ActionType.POST)).Union(clientPostAction).Where(x => !deleteEntitiesIds.Contains(x.EntityId)).OrderBy(s => ParseToDateTime(s.ActionDate)).Distinct(new SyncEntityComparer()).ToList();
        }

        private async Task<List<SyncEntity>> GetPutActionsWithoutDeleteActionsByIds(Guid userId,
            string syncDate, IEnumerable<SyncEntity> clientPutAction, ICollection<Guid> deleteEntitiesIds)
        {
            return (await _auditService.GetAllEventsByTypeAfterDate(userId, syncDate, ActionType.PUT)).Union(clientPutAction).Where(x => !deleteEntitiesIds.Contains(x.EntityId)).OrderBy(s => ParseToDateTime(s.ActionDate)).Distinct(new SyncEntityComparer()).ToList();
        }

        private async Task<List<SyncEntity>> GetDeleteActions(Guid userId, SynchronizationClientDataContract clientSynchronizationDataContract)
        {
            var deleteAction = await _auditService.GetAllEventsByTypeAfterDate(userId,
                clientSynchronizationDataContract.LastSyncDate, ActionType.DELETE);
            return deleteAction.Where(x => !clientSynchronizationDataContract.Delete.Select(s => s.EntityId).Contains(x.EntityId)).OrderByDescending(s => s.ActionDate).ToList();
        }

        private async Task DeleteEntitiesFromServer(Guid userId, IEnumerable<SyncEntity> entities)
        {
            foreach (var e in entities)
            {
                if (e.EntityName == "CARS")
                    await _carsService.DeleteShareCarAsync(e.EntityId, userId);
                if (e.EntityName == "EVENTS")
                    await _eventsService.DeleteCarEventAsync(e.EntityId);
            }
        }

        private static DateTime ParseToDateTime(string lastDateSync)
        {
            if (lastDateSync.Length > 19)
                lastDateSync = lastDateSync.Remove(19);
            return DateTime.ParseExact(lastDateSync, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
