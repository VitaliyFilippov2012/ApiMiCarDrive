using System;
using System.Collections.Generic;

#nullable disable

namespace DBContext.Models
{
    public partial class FuelType
    {
        public FuelType()
        {
            Cars = new HashSet<Car>();
        }

        public Guid FuelTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
