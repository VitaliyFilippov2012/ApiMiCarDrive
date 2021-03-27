using System;
using System.Collections.Generic;

#nullable disable

namespace DBContext.Models
{
    public partial class Right
    {
        public Right()
        {
            UsersCarsRights = new HashSet<UsersCarsRight>();
        }

        public Guid RightId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UsersCarsRight> UsersCarsRights { get; set; }
    }
}
