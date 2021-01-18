using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OLImageRepository.Models
{
    public partial class Album : IValidatableObject
    {
        private const int MAX_NAME_LENGTH = 20;
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Name.Length > MAX_NAME_LENGTH)
            {
                yield return new ValidationResult($"Name must be up to {MAX_NAME_LENGTH} characters long", new[] { nameof(Name) });
            }

            yield return ValidationResult.Success;
        }
    }

    public class AlbumMetadata
    {
        [Required]
        [Display(Name = "Picture Name")]
        public string Name { get; set; }
    }
}
