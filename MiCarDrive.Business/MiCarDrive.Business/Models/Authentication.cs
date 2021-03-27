using System;
using System.Collections.Generic;

#nullable disable

namespace DBContext.Models
{
    public partial class Authentication
    {
        public Guid UserId { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }

        public virtual User User { get; set; }
    }
}
