using System;
using System.Collections.Generic;

#nullable disable

namespace DBContext.Models
{
    public partial class Detail
    {
        public Guid DetailId { get; set; }
        public Guid CarId { get; set; }
        public Guid ServiceId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public virtual Car Car { get; set; }
        public virtual CarService Service { get; set; }
    }
}
