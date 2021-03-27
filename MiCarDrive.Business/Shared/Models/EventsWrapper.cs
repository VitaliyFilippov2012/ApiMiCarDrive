using System;
using System.Collections.Generic;

namespace Shared.Models
{
    [Serializable]
    public class EventsWrapper
    {
        public IEnumerable<EventService> EventServices { get; set; }
        public IEnumerable<Event> Events { get; set; }
        public IEnumerable<Refill> Refills { get; set; }
    }
}
