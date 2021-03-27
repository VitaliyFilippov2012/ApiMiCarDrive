using System;
using System.Collections.Generic;

#nullable disable

namespace DBContext.Models
{
    public partial class UsersCarsRole
    {
        public Guid RoleId { get; set; }
        public Guid UserCarId { get; set; }

        public virtual Role Role { get; set; }
        public virtual UsersCar UserCar { get; set; }
    }
}
