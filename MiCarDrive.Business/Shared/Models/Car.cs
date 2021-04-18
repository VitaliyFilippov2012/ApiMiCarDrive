using System;

namespace Shared.Models
{
    [Serializable]
    public class Car
    {
        public Guid? CarId { get; set; }
        public Guid FuelTypeId { get; set; }
        public Guid TransmissionTypeId { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public int VolumeEngine { get; set; }
        public int Power { get; set; }
        public bool Active { get; set; }
        public string Vin { get; set; }
        public string Comment { get; set; }
        public int YearIssue { get; set; }
    }
}
