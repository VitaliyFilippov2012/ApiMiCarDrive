using System;
using System.Collections.Generic;

#nullable disable

namespace DBContext.Models
{
    public partial class CarEvent
    {
        public CarEvent()
        {
            CarServices = new HashSet<CarService>();
            Refills = new HashSet<Refill>();
        }

        public Guid EventId { get; set; }
        public Guid EventTypeId { get; set; }
        public Guid UserCarId { get; set; }
        public DateTime Date { get; set; }
        public decimal Costs { get; set; }
        public decimal? UnitPrice { get; set; }
        public string Comment { get; set; }
        public long? Mileage { get; set; }
        public Guid? PhotoArchiveId { get; set; }
        public string AddressStation { get; set; }

        public virtual EventType EventType { get; set; }
        public virtual PhotoArchive PhotoArchive { get; set; }
        public virtual UsersCar UserCar { get; set; }
        public virtual ICollection<CarService> CarServices { get; set; }
        public virtual ICollection<Refill> Refills { get; set; }
    }
}
