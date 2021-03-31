﻿using System;
using System.Collections.Generic;

namespace Shared.Models
{
    [Serializable]
    public class EventService : Event
    {
        public Guid ServiceId { get; set; }
        public Guid ServiceTypeId { get; set; }
        public string Name { get; set; }
        public IEnumerable<Detail> Details { get; set; }
    }
}
