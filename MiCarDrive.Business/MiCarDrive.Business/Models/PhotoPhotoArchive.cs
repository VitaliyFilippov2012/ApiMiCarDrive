using System;
using System.Collections.Generic;

#nullable disable

namespace DBContext.Models
{
    public partial class PhotoPhotoArchive
    {
        public Guid PhotoArchiveId { get; set; }
        public Guid PhotoId { get; set; }

        public virtual Photo Photo { get; set; }
        public virtual PhotoArchive PhotoArchive { get; set; }
    }
}
