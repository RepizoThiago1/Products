using Products.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Products.Domain.DTO.Reference
{
    public class ProductReferencesDTO
    {
        [Required]
        public string SKU { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public float Weight { get; set; }

        [Required]
        public float Size { get; set; }

        [Required]
        public float MaximumWeightAllowed { get; set; }

        [Required]
        public float MinimumWeightAllowed { get; set; }

        [Required]
        public float MaximumSizeAllowed { get; set; }

        [Required]
        public float MinimumSizeAllowed { get; set; }

        [Required]
        public MaterialType MaterialType { get; set; }
    }
}
