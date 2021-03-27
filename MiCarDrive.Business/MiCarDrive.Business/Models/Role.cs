using System;
using System.Collections.Generic;

#nullable disable

namespace DBContext.Models
{
    public partial class Role
    {
        public Role()
        {
            UsersCarsRoles = new HashSet<UsersCarsRole>();
        }

        public Guid RoleId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UsersCarsRole> UsersCarsRoles { get; set; }
    }
}
