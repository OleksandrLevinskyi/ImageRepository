using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OLImageRepository.Models
{
    public partial class Album
    {
        public Album()
        {
            Picture = new HashSet<Picture>();
        }

        public int AlbumId { get; set; }
        public string OwnerId { get; set; }
        public string Name { get; set; }

        public virtual AspNetUsers Owner { get; set; }
        public virtual ICollection<Picture> Picture { get; set; }
    }
}
