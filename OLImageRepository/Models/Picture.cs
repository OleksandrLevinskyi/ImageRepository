using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OLImageRepository.Models
{
    public partial class Picture
    {
        public int PictureId { get; set; }
        public int? AlbumId { get; set; }
        public string OwnerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] StoredPicture { get; set; }
        public DateTime DateAdded { get; set; }
        public string DominantColor { get; set; }
        public bool IsPublic { get; set; }
        public bool IsHorizontal { get; set; }

        public virtual Album Album { get; set; }
        public virtual AspNetUsers Owner { get; set; }
    }
}
