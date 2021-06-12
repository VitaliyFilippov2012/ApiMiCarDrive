using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Shared.Models
{
    [Serializable]
    [DataContract]
    public class SynchronizationClientDataContract
    {
        [DataMember(Order = 0)]
        public string LastSyncDate { get; set; }

        [DataMember(Order = 0)]
        public IEnumerable<SyncEntity> Delete { get; set; }

        [DataMember(Order = 0)]
        public IEnumerable<SyncEntity> Post { get; set; }

        [DataMember(Order = 0)]
        public IEnumerable<SyncEntity> Put { get; set; }
    }
}
