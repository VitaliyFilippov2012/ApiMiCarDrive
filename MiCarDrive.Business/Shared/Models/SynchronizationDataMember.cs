using System;

namespace Shared.Models
{
    [Serializable]
    public class SynchronizationDataMember
    {
        public string Entity { get; set; }
        public Guid EntityId { get; set; }
        public string ActionType { get; set; }
        public string ActionSide { get; set; }
        public string ActionDate { get; set; }
    }
}
