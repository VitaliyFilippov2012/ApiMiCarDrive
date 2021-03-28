using System;

namespace Shared.Models
{
    [Serializable]
    public class Detail
    {
        public Guid DetailId { get; set; }
        public Guid CarId { get; set; }
        public Guid ServiceId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
