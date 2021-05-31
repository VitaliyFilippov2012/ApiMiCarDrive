using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models
{
    [Serializable]
    public class SyncEntity
    {
        public string EntityName { get; set; }

        public Guid EntityId { get; set; }

        public string ActionDate { get; set; }

        public string ActionSide { get; set; } = Enums.ActionSide.Client.ToString();
    }

    public class SyncEntityComparer : IEqualityComparer<SyncEntity>
    {
        public bool Equals(SyncEntity x, SyncEntity y)
        {
            return x != null && (y != null && x.EntityId == y.EntityId);
        }

        public int GetHashCode(SyncEntity obj)
        {
            return obj.EntityId.GetHashCode();
        }
    }
}
