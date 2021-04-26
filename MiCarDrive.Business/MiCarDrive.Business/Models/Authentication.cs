using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
