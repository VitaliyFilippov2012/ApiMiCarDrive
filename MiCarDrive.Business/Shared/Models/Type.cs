using System;

namespace Shared.Models
{
    [Serializable]
    public class Type
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
