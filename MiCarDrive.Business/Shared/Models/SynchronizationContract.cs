using System;
using System.Collections.Generic;

namespace Shared.Models
{
    [Serializable]
    public class SynchronizationContract
    {
        public string LastSyncDate { get; set; }

        public List<SynchronizationDataMember> SynchronizationDataMembers { get; set; }
    }
}
