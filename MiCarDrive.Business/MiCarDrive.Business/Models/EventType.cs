using System;
using System.Collections.Generic;

#nullable disable

namespace DBContext.Models
{
    public partial class EventType
    {
        public EventType()
        {
            CarEvents = new HashSet<CarEvent>();
        }

        public Guid EventTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CarEvent> CarEvents { get; set; }
    }
}
