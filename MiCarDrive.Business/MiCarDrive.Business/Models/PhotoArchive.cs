using System;
using System.Collections.Generic;

#nullable disable

namespace DBContext.Models
{
    public partial class PhotoArchive
    {
        public PhotoArchive()
        {
            CarEvents = new HashSet<CarEvent>();
            Cars = new HashSet<Car>();
            PhotoPhotoArchives = new HashSet<PhotoPhotoArchive>();
            Users = new HashSet<User>();
        }

        public Guid PhotoArchiveId { get; set; }
        public string Path { get; set; }

        public virtual ICollection<CarEvent> CarEvents { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<PhotoPhotoArchive> PhotoPhotoArchives { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
