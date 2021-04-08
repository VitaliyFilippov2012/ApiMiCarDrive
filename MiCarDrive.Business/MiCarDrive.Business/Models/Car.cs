using System;
using System.Collections.Generic;

#nullable disable

namespace DBContext.Models
{
    public partial class Car
    {
        public Car()
        {
            Details = new HashSet<Detail>();
            UsersCars = new HashSet<UsersCar>();
        }

        public Guid CarId { get; set; }
        public Guid FuelTypeId { get; set; }
        public Guid TransmissionTypeId { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public int VolumeEngine { get; set; }
        public int Power { get; set; }
        public bool? Active { get; set; }
        public string Vin { get; set; }
        public string Color { get; set; }
        public string RegistrationNumber { get; set; }
        public Guid? PhotoArchiveId { get; set; }
        public int YearIssue { get; set; }

        public virtual FuelType FuelType { get; set; }
        public virtual PhotoArchive PhotoArchive { get; set; }
        public virtual TransmissionType TransmissionType { get; set; }
        public virtual ICollection<Detail> Details { get; set; }
        public virtual ICollection<UsersCar> UsersCars { get; set; }
    }
}
