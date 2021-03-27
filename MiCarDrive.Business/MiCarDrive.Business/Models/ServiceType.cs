using System;
using System.Collections.Generic;

#nullable disable

namespace DBContext.Models
{
    public partial class ServiceType
    {
        public ServiceType()
        {
            CarServices = new HashSet<CarService>();
        }

        public Guid ServiceTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CarService> CarServices { get; set; }
    }
}
