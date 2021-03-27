using System;
using System.Collections.Generic;

#nullable disable

namespace DBContext.Models
{
    public partial class ActionAudit
    {
        public string Entity { get; set; }
        public Guid EntityId { get; set; }
        public Guid UserId { get; set; }
        public string Action { get; set; }
        public string DateUpdate { get; set; }

        public virtual User User { get; set; }
    }
}
