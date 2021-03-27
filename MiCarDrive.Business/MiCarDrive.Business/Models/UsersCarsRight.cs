using System;
using System.Collections.Generic;

#nullable disable

namespace DBContext.Models
{
    public partial class UsersCarsRight
    {
        public Guid RightId { get; set; }
        public Guid UserCarId { get; set; }

        public virtual Right Right { get; set; }
        public virtual UsersCar UserCar { get; set; }
    }
}
