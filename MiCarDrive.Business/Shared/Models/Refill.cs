using System;

namespace Shared.Models
{
    [Serializable]
    public class Refill : Event
    {
        public Guid RefillId { get; set; }
        public float Volume { get; set; }
    }
}
