using System;
using System.Collections.Generic;

namespace Shared.Models
{
    [Serializable]
    public class SynchronizationClientDataContract
    {
        public string LastSyncDate { get; set; }
        public List<SyncEntity> Delete { get; set; }
        public List<SyncEntity> Post { get; set; }
        public List<SyncEntity> Put { get; set; }
    }
}
