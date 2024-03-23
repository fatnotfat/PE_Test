using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Request
{
    public class SilverJewelryCreateDTO
    {
        [Required(ErrorMessage = "SilverJewelryId is required.")]

        public string SilverJewelryId { get; set; } = null!;

        [Required(ErrorMessage = "SilverJewelryName is required.")]
        [RegularExpression(@"^[A-Z][a-zA-Z0-9\s]*$", ErrorMessage = "SilverJewelryName must start with an uppercase letter and contain only letters (uppercase and lowercase), numbers, and spaces.")]

        public string SilverJewelryName { get; set; } = null!;

        [Required(ErrorMessage = "SilverJewelryDescription is required.")]

        public string? SilverJewelryDescription { get; set; }

        [Required(ErrorMessage = "MetalWeight is required.")]

        public decimal? MetalWeight { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Price must be greater than 0.")]

        public decimal? Price { get; set; }

        [Required(ErrorMessage = "ProductionYear is required.")]
        [Range(1900, int.MaxValue, ErrorMessage = "Production year must be greater than or equal to 1900.")]
        public int? ProductionYear { get; set; }

        [Required(ErrorMessage = "CreatedDate is required.")]

        public string? CategoryId { get; set; }
    }
}
