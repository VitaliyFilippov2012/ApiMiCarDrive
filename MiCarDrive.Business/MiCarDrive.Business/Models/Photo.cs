using System;
using System.Collections.Generic;

#nullable disable

namespace DBContext.Models
{
    public partial class Photo
    {
        public Photo()
        {
            PhotoPhotoArchives = new HashSet<PhotoPhotoArchive>();
        }

        public Guid PhotoId { get; set; }
        public string Name { get; set; }
        public string Expansion { get; set; }

        public virtual ICollection<PhotoPhotoArchive> PhotoPhotoArchives { get; set; }
    }
}
