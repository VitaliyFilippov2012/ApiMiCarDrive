using System;

#nullable disable

namespace DBContext.Models
{
    public partial class Refill
    {
        public Guid RefillId { get; set; }
        public Guid EventId { get; set; }
        public float Volume { get; set; }

        public virtual CarEvent Event { get; set; }
    }
}
