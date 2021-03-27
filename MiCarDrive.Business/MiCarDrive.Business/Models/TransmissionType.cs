using System;
using System.Collections.Generic;

#nullable disable

namespace DBContext.Models
{
    public partial class TransmissionType
    {
        public TransmissionType()
        {
            Cars = new HashSet<Car>();
        }

        public Guid TransmissionTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
