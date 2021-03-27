using System;
using System.Collections.Generic;

#nullable disable

namespace DBContext.Models
{
    public partial class User
    {
        public User()
        {
            ActionAudits = new HashSet<ActionAudit>();
            Authentications = new HashSet<Authentication>();
            UsersCars = new HashSet<UsersCar>();
        }

        public Guid UserId { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public Guid? PhotoArchiveId { get; set; }

        public virtual PhotoArchive PhotoArchive { get; set; }
        public virtual ICollection<ActionAudit> ActionAudits { get; set; }
        public virtual ICollection<Authentication> Authentications { get; set; }
        public virtual ICollection<UsersCar> UsersCars { get; set; }
    }
}
