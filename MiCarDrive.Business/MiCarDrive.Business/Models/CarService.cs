using System;
using System.Collections.Generic;

#nullable disable

namespace DBContext.Models
{
    public partial class CarService
    {
        public CarService()
        {
            Details = new HashSet<Detail>();
        }

        public Guid ServiceId { get; set; }
        public Guid EventId { get; set; }
        public Guid ServiceTypeId { get; set; }
        public string Name { get; set; }

        public virtual CarEvent Event { get; set; }
        public virtual ServiceType TypeService { get; set; }
        public virtual ICollection<Detail> Details { get; set; }
    }
}
