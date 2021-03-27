using System;

namespace Shared.Models
{
    [Serializable]
    public class Type
    {
        public Guid TypeId { get; set; }

        public string TypeName { get; set; }
    }
}
