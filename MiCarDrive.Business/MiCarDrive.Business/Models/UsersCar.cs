using System;
using System.Collections.Generic;

#nullable disable

namespace DBContext.Models
{
    public partial class UsersCar
    {
        public UsersCar()
        {
            CarEvents = new HashSet<CarEvent>();
            UsersCarsRights = new HashSet<UsersCarsRight>();
            UsersCarsRoles = new HashSet<UsersCarsRole>();
        }

        public Guid UserCarId { get; set; }
        public Guid UserId { get; set; }
        public Guid CarId { get; set; }

        public virtual Car Car { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<CarEvent> CarEvents { get; set; }
        public virtual ICollection<UsersCarsRight> UsersCarsRights { get; set; }
        public virtual ICollection<UsersCarsRole> UsersCarsRoles { get; set; }
    }
}
