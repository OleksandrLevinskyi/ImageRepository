using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OLImageRepository.Models
{
    [ModelMetadataType(typeof(PictureMetadata))]
    public partial class Picture : IValidatableObject
    {
        private const int MAX_NAME_LENGTH = 20;
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            DateAdded = DateTime.Now;

            if (Name.Length > MAX_NAME_LENGTH)
            {
                yield return new ValidationResult($"Name must be up to {MAX_NAME_LENGTH} characters long", new[] { nameof(Name) });
            }

            yield return ValidationResult.Success;
        }
    }

    public class PictureMetadata
    {
        public int PictureId { get; set; }

        [Display(Name = "Album")]
        public int? AlbumId { get; set; }

        [Required]
        [Display(Name = "Picture Name")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public byte[] StoredPicture { get; set; }

        [Display(Name = "Last Modified")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Dominant Color")]
        public string DominantColor { get; set; }

        [Display(Name = "Allow Public Access")]
        public bool IsPublic { get; set; }

        [Display(Name = "Orientation")]
        public bool IsHorizontal { get; set; }
    }
}
