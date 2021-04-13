using System;

namespace Shared.Models
{
    [Serializable]
    public class Event
    {
        public Guid EventId { get; set; }
        public Guid EventTypeId { get; set; }
        public string Name { get; set; }
        public Guid UserCarId { get; set; }
        public Guid CarId { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public decimal Costs { get; set; }
        public decimal? UnitPrice { get; set; }
        public string Comment { get; set; }
        public long? Mileage { get; set; }
        public Guid? PhotoArchiveId { get; set; }
        public string AddressStation { get; set; }
    }
}
